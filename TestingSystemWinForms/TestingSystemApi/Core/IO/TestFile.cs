using System;

namespace TestingSystemApi.Core.IO
{
    /// <summary>
    /// This struct represents test appeareance in UI containers (such as listBox/View)
    /// </summary>
    public struct TestFile
    {
        public string TestName { get; set; }
        public string TestLocation { get; set; }
    }
}
