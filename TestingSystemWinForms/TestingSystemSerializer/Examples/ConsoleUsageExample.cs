using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestingSystemApi;
using TestingSystemApi.Serializer;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating new empty test object

            TestItem myTest = new TestItem("TestName");

            //example of creating a question with answers (long version)

            /*
             *  TestQuestion testQuestion = new TestQuestion();
             *  testQuestion.Id = 0;
             *  testQuestion.Question = "Your question goes here";
             *
             *  List<string> answers = new List<string>();
             *  answers.AddRange(new string[] {"answer1", "answer2"});
             *
             *  testQuestion.Answers.AddRange(answers);
             *
             *  myTest.Questions.Add(testQuestion);
             */



            //short version
            /*
             
             myTest.Questions.AddRange(new TestQuestion[]
                {
                    new TestQuestion() 
                    {
                        Id = 0,
                        Question = "How old are you ?",
                        
                        Answers = new List<string>
                        {
                            "younger than 18",
                            "younger than 40",
                            "older than 70"
                        }
                    },

                    new TestQuestion()
                    {
                        Id = 1,
                        Question = "Do you like this test ?",

                        Answers = new List<string>
                        {
                            "surely yes!",
                            "it's not that bad",
                            "it sucks m8 get rekt"
                        }
                    }
                });
             
             */

            //Creating a json text serializer with the test object we want to serialize
            JsonTestSerializer jsonTestSerializer = new JsonTestSerializer(myTest);

            //serializing a json 
            //it's better to use try .. catch here since Serialize method throws exceptions

            try
            { 
                string serializedJson = jsonTestSerializer.Serialize();
                Console.WriteLine(serializedJson);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey(true);
        }
    }
}
