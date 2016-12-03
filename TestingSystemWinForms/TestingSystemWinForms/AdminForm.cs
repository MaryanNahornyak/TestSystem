using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            //prevent form closing and hide it instead
            this.FormClosing += ((s, ev) =>
                {
                    ev.Cancel = true;
                    this.Hide();
                });
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            newTestItem = new TestItem(testNameTextBox.Text);
            numberOfQuestions = Convert.ToInt32(questionsTextBox.Text);
            numberOfAnswers = Convert.ToInt32(answersComboBox.Text);

            confirmButton.Hide();
            label1.Hide();
            label3.Hide();
            testNameTextBox.Hide();
            testNameTextBox.Text = "";
            answersComboBox.Hide();
            addButton.Visible = true;

            label2.Text = "Question";
            this.questionsTextBox.Location = new System.Drawing.Point(50, 126);
            this.questionsTextBox.Size = new System.Drawing.Size(160, 20);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
           if(label2.Text.Contains("Question"))
            {
                addQuestionName();
            }
           else if(label2.Text.Contains("Answer"))
            {
                addAnswer();
            }
           else if(label2.Text.Contains("Correct"))
            {
                int correctId = Convert.ToInt32(questionsTextBox.Text);
                if(correctId < 0 || correctId > numberOfAnswers)
                {
                    MessageBox.Show("There is no such answer id");
                }
                else
                setCorrectAnswerId(correctId - 1);
            }
        }

        private void addQuestionName()
        {
            newQuestion = new TestQuestion();
            newQuestion.Answers = new List<string>();
            newQuestion.Question = questionsTextBox.Text;
            newQuestion.Id = newTestItem.Questions.Count;
            numberOfQuestions--;
            label2.Text = "Answer 1";
            questionsTextBox.Text = "";
        }


        /// <summary>
        /// Answer add method
        /// </summary>
        private void addAnswer()
        {
           
                newQuestion.Answers.Add(questionsTextBox.Text);
                label2.Text = "Answer " + (newQuestion.Answers.Count + 1).ToString();

            if (newQuestion.Answers.Count == numberOfAnswers)
                label2.Text = "Correct answer id from 1 to " + (newQuestion.Answers.Count).ToString();
            questionsTextBox.Text = "";

        }


        /// <summary>
        /// Add correct answer id, and if it`s lust question confirm the test
        /// </summary>
        /// <param name="correctId"></param>
        private void setCorrectAnswerId(int correctId)
        {
            newQuestion.CorrectAnswerId = correctId;
            newTestItem.Questions.Add(newQuestion);
            if (numberOfQuestions > 0)
            {
                label2.Text = "Question " + newTestItem.Questions.Count.ToString();
            }
            else
            {
                addButton.Visible = false;
                confirmButton.Show();
                label1.Show();
                label3.Show();
                testNameTextBox.Show();
                answersComboBox.Show();
                this.questionsTextBox.Location = new System.Drawing.Point(89, 126);
                this.questionsTextBox.Size = new System.Drawing.Size(100, 20);
                questionsTextBox.Text = "";
                label2.Text = "Number of questions";
            }
        }
    }
}
