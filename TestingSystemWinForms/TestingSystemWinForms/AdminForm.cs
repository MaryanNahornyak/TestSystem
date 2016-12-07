using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystemApi.Core;
using TestingSystemApi.Serializer;


namespace TestingSystemWinForms
{
    public partial class AdminForm : Form
    {

        TestItem newTestItem;
        TestQuestion newQuestion;
        int numberOfQuestions;
        int numberOfAnswers;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }


        /**
        * Start creating tests
        */
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text == "" || questionsTextBox.Text == "")
            {
                MessageBox.Show("Not all fields are filled");
            }
            else
            {
                newTestItem = new TestItem(testNameTextBox.Text);
                numberOfQuestions = Convert.ToInt32(questionsTextBox.Text);


                testFillerAdd();
            }
        }


        /**
        * Adding questions and answers
        */
        private void addButton_Click(object sender, EventArgs e)
        {
            if (label2.Text.Contains("Question"))
            {
                if (questionsTextBox.Text != "" || answersComboBox.SelectedItem != null || answersComboBox.SelectedText != "")
                    addQuestionName();
                else
                    MessageBox.Show("Fill in the question and add count of numbers");
            }
            else if (label2.Text.Contains("Answer"))
            {
                if (questionsTextBox.Text != "")
                    addAnswer();
                else
                    MessageBox.Show("Fill in the answer");
            }
            else if (label2.Text.Contains("Correct"))
            {
                if (questionsTextBox.Text != "")
                {
                    int correctId = Convert.ToInt32(questionsTextBox.Text);
                    if (correctId < 0 || correctId > numberOfAnswers)
                    {
                        MessageBox.Show("There is no such answer id");
                    }
                    else
                    {
                        setCorrectAnswerId(correctId - 1);
                        
                    }
                }
            }
        }


        /**
        * Question add method
        */
        private void addQuestionName()
        {
            if (answersComboBox.SelectedItem != null || answersComboBox.SelectedText != "")
            {
                numberOfAnswers = Convert.ToInt32(answersComboBox.SelectedItem.ToString());
                answersComboBox.Visible = true;
                label3.Visible = true;
                newQuestion = new TestQuestion();
                newQuestion.Answers = new List<string>();
                newQuestion.Question = questionsTextBox.Text;
                newQuestion.Id = newTestItem.Questions.Count;
                numberOfQuestions--;
                answersComboBox.Visible = false;
                label3.Visible = false;
                label2.Text = "Answer 1";
                questionsTextBox.Text = "";
            }
            else
                MessageBox.Show("Fill in the answer");

        }


        /**
        * Answer add method
        */
        private void addAnswer()
        {
            answersComboBox.Visible = false;
            label3.Visible = false;
            newQuestion.Answers.Add(questionsTextBox.Text);

            if (newQuestion.Answers.Count == numberOfAnswers)
                label2.Text = "Correct answer id from 1 to " + (newQuestion.Answers.Count).ToString();
            else
                label2.Text = "Answer " + (newQuestion.Answers.Count + 1).ToString();

            questionsTextBox.Text = "";

        }


        /**
        * Add correct answer id, and if it`s last question confirm the test
        */
        private void setCorrectAnswerId(int correctId)
        {
            newQuestion.CorrectAnswerId = correctId;
            newTestItem.Questions.Add(newQuestion);
            if (numberOfQuestions > 0)
            {
                answersComboBox.Visible = true;
                label3.Visible = true;
                label2.Text = "Question " + (newTestItem.Questions.Count + 1).ToString();
                //answersComboBox.Visible = true;
            }
            else
            {
                backToTestAdding();
                JsonTestSerializer serializer = new JsonTestSerializer();
                string jsonString = serializer.Serialize(newTestItem);

                MessageBox.Show("Choose directory for test to be saved");

                using (SaveFileDialog op = new SaveFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(op.FileName, jsonString);
                    }
                }
            }
        }

        /**
        * Return to creating a new test
        */
        private void backToTestAdding()
        {
            addButton.Visible = false;
            confirmButton.Show();
            label1.Show();
            label3.Hide();
            testNameTextBox.Show();
            testNameTextBox.Text = "";
            answersComboBox.Hide();
            answersComboBox.SelectedItem = "";
            this.questionsTextBox.Location = new System.Drawing.Point(82, 93);
            this.questionsTextBox.Size = new System.Drawing.Size(100, 20);
            questionsTextBox.Text = "";
            label2.Text = "Number of questions";
        }

        /**
        * Changing for to fill questions and answers
        */
        private void testFillerAdd()
        {
            confirmButton.Hide();
            label1.Hide();
            label3.Hide();
            testNameTextBox.Hide();
            testNameTextBox.Text = "";
            answersComboBox.Hide();
            addButton.Visible = true;
            answersComboBox.Visible = true;
            label3.Visible = true;

            label2.Text = "Question 1";
            questionsTextBox.Text = "";
            this.questionsTextBox.Location = new System.Drawing.Point(50, 126);
            this.questionsTextBox.Size = new System.Drawing.Size(160, 20);
        }

    }
}
