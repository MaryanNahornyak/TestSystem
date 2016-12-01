using System;
using System.Linq;
using System.Collections.Generic;

namespace TestingSystemApi.Core
{
    /// <summary>
    /// Question structure that represents necessary data
    /// for client side
    /// </summary>
    public struct TestQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
	public int CorrectAnswerId { get; set; }
        public List<string> Answers { get; set; }
    }

    /// <summary>
    /// Base test item
    /// </summary>
    public sealed class TestItem
    {
        #region Properties

        public List<TestQuestion> Questions { get; set; }

        public string TestName
        {
            get
            {
                return testName;
            }
        }

        #endregion



        #region Private fields

        private string testName;

        #endregion


        #region Constructor

        public TestItem(string testName)
        {
            this.testName = testName;
            this.Questions = new List<TestQuestion>();
        }

        public TestItem(string testName, TestQuestion[] questionsArray)
        {
            this.testName = testName;
            this.Questions = questionsArray.ToList();
        }

        #endregion
    }
}
