using System;
using System.Collections.Generic;
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

        TestSystemSerializer jsonSerializer;

        public ClientForm()
        {
            InitializeComponent();

            testFiles = new List<TestFile>();

            jsonSerializer = new JsonTestSerializer();

            threadLock = new object();

            //prevent form closing and hide it instead
            this.FormClosing += ((s, ev) =>
            {
                ev.Cancel = true;
                this.Hide();
            });
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void ReadTestsFromSelectedFolder(object threadInfo)
        {
            ThreadInfo threadInfoObj = (ThreadInfo)threadInfo;

            //get a serializer object so we could search fiels for specific pattern
            TestSystemSerializer serializer = threadInfoObj.Serialier;
            string[] files = Directory.GetFiles(threadInfoObj.TestsPath, serializer.TestItemSearchPattern);

            foreach (var fileLocation in files)
            {
                lock (threadLock)
                {
                    using (StreamReader sr = new StreamReader(fileLocation))
                    {
                        string test = sr.ReadToEnd();

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
    }
}
