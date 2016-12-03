using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TestingSystemApi.Core;
using TestingSystemApi.Core.IO;
using TestingSystemApi.Serializer;

namespace TestingSystemWinForms
{
    /// <summary>
    /// Structure that provides pattern for searching tests
    /// </summary>
    public struct ThreadInfo
    {
        public TestSystemSerializer Serialier { get; set; }
        public string TestsPath { get; set; }
        public List<TestFile> TestFiles { get; set; }
    }

    public partial class ClientForm : Form
    {
        object threadLock;

        public List<TestFile> testFiles;

        List<RadioButton> answers;

        TestSystemSerializer jsonSerializer;

        TestItem selectedTest;
        int currentQuestionIndex;
        int correctQuestionsCount;

        public ClientForm()
        {
            InitializeComponent();

            testFiles = new List<TestFile>();

            jsonSerializer = new JsonTestSerializer();
            answers = new List<RadioButton>();

            threadLock = new object();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ReadTestsFromSelectedFolder(object threadInfo)
        {
            ThreadInfo threadInfoObj = (ThreadInfo)threadInfo;

            //get a serializer object so we could search files wth specific pattern
            TestSystemSerializer serializer = threadInfoObj.Serialier;
            string[] files = Directory.GetFiles(threadInfoObj.TestsPath, serializer.TestItemSearchPattern);

            foreach (var fileLocation in files)
            {
                lock (threadLock)
                {
                    using (StreamReader sr = new StreamReader(fileLocation))
                    {
                        string test = sr.ReadToEnd();

                        //check if specific file is a serialized test object
                        //otherwise skip it
                        if (serializer.IsTestValid(test))
                        {
                            TestFile testFile = new TestFile();
                            testFile.TestName = serializer.Deserialize(test).TestName;
                            testFile.TestLocation = fileLocation;

                            threadInfoObj.TestFiles.Add(testFile);

                            testList.Invoke(new Action(() => testList.Items.Add(testFile.TestName)));
                        }
                    }
                }
            }
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fOpen = new FolderBrowserDialog())
            {
                if (fOpen.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = fOpen.SelectedPath;

                    //filling info for next thread
                    ThreadInfo threadInfo = new ThreadInfo();
                    threadInfo.Serialier = jsonSerializer;
                    threadInfo.TestFiles = testFiles;
                    threadInfo.TestsPath = selectedFolder;

                    ThreadPool.QueueUserWorkItem(
                        new WaitCallback(ReadTestsFromSelectedFolder),
                        threadInfo
                    );
                }
            }
        }

        private void ClearQuestionForm()
        {
            for (int i = 0; i < answers.Count; i++)
            {
                testPanel.Controls.Remove(answers[i]);
            }

            answers.Clear();
        }

        /// <summary>
        /// This method spawns radiobuttons as a selectable options
        /// </summary>
        private void SpawnAnswerOptions()
        {
            int yOffset = this.Size.Height / 10;

            int QuestionSpaceY = this.Size.Height - (this.Size.Height / 3);
            
            int ySize = QuestionSpaceY / selectedTest.Questions[currentQuestionIndex].Answers.Count;
            int xOffset = 5;

            questionLabel.Text = selectedTest.Questions[currentQuestionIndex].Question;

            for (int i = 0; i < selectedTest.Questions[currentQuestionIndex].Answers.Count; i++)
            {
                RadioButton answerButton = new RadioButton()
                {
                    Location = new Point(xOffset, yOffset + (ySize * i)),
                    Text = selectedTest.Questions[currentQuestionIndex].Answers[i]
                };

                //add answer button to both test panel to render it and answers
                //list to be able check their state and update
                testPanel.Controls.Add(answerButton);
                answers.Add(answerButton);
            }
        }

        /// <summary>
        /// Checks if selected radiobutton text equals correct answer
        /// </summary>
        /// <param name="answer">Checked radiobutton text</param>
        /// <returns>Value which determines whether user selected correct radio button</returns>
        private bool AnswerIsCorrect(string answer)
        {
            int correctAnswerId = selectedTest.Questions[currentQuestionIndex].CorrectAnswerId;

            return answer == selectedTest.Questions[currentQuestionIndex].Answers[correctAnswerId];
        }

        private void testBegin_Click(object sender, EventArgs e)
        {
            if(testList.SelectedItem != null)
            {
                TestFile testFile;
                foreach(var test in testFiles)
                {
                    //we search for specific test in TestFile structure so we could obtain it's path
                    if(test.TestName == testList.SelectedItem.ToString())
                    {
                        testFile = test;
                        break;
                    }
                }

                testPanel.Show();

                currentQuestionIndex = 0;
                correctQuestionsCount = 0;

                string testString = File.ReadAllText(testFile.TestLocation);

                selectedTest = jsonSerializer.Deserialize(testString);

                ClearQuestionForm();
                SpawnAnswerOptions();
                UpdateQuestionProgress();
            }
        }

        public void EndTest()
        {
            MessageBox.Show("You answered correctly : " + correctQuestionsCount + " of " + selectedTest.Questions.Count);
            testPanel.Hide();
        }

        /// <summary>
        /// This method trakcs question progress on nextQuestionButton object
        /// example - Next (5/14)
        /// </summary>
        private void UpdateQuestionProgress()
        {
            int questionCount = selectedTest.Questions.Count;

            nextQuestionButton.Text = String.Format("Next ({0}/{1})", currentQuestionIndex + 1, questionCount);
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < answers.Count; i++)
            {
                if(answers[i].Checked)
                {
                    correctQuestionsCount += AnswerIsCorrect(answers[i].Text) ? 1 : 0;

                    ClearQuestionForm();

                    if (currentQuestionIndex + 1 < selectedTest.Questions.Count)
                    {
                        currentQuestionIndex++;
                        UpdateQuestionProgress();
                        SpawnAnswerOptions();
                    }
                    else
                    {
                        EndTest();
                    }
                }
            }
        }
    }
}
