using System;
using System.Collections.Generic;

namespace TestingSystemApi.Serializer
{
    public abstract class TestSystemSerialization
    {
        #region Properties

        public TestItem TestItem
        {
            get
            {
                return testItem;
            }
        }

        #endregion

        #region Private fields

        TestItem testItem;

        #endregion

        #region Abstract class realisation

        public TestSystemSerialization(TestItem test)
        {
            this.testItem = test;
        }

        /// <summary>
        /// This method serializes an array of test questions
        /// using a specific text formats
        /// </summary>
        public abstract string Serialize();

        #endregion
    }
}
