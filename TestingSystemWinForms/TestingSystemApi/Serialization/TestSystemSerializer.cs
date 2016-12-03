using System;
using System.Collections.Generic;

using TestingSystemApi.Core;

namespace TestingSystemApi.Serializer
{
    public abstract class TestSystemSerializer
    {
        #region Properties

        public TestItem TestItem { get; set; }

        public string TestItemSearchPattern { get; protected set; }

        #endregion

        #region Private fields

        TestItem testItem;

        #endregion

        #region Abstract class realisation

        /// <summary>
        /// This method serializes an array of test questions
        /// using a specific text formats
        /// </summary>
        public abstract string Serialize(TestItem testItem);

        public abstract TestItem Deserialize(string path);

        /// <summary>
        /// Checks if  
        /// </summary>
        /// <param name="testText"></param>
        /// <returns></returns>
        public abstract bool IsTestValid(string testText);

        #endregion
    }
}
