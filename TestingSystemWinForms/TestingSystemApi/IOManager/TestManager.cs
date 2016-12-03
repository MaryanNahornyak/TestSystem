using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemSerializer.IOManager
{
    public class TestManager
    {
        public bool JsonIsATestFile(string json)
        {
            return json.Contains("test_name") && json.Contains("questions");
        }
    }
}
