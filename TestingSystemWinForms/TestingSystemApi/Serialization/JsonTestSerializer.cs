using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.IO;
using System.Linq;

using TestingSystemApi.Core;

using Newtonsoft.Json.Linq;

namespace TestingSystemApi.Serializer
{
    public sealed class JsonTestSerializer : TestSystemSerializer
    {
        public JsonTestSerializer()
        {
            this.TestItemSearchPattern = "*.json";
        }

        /// <summary>
        /// This class serializes each question individually into json format
        /// </summary>
        /// <param name="question">question struct object to serialize</param>
        /// <param name="json">json writer reference</param>
        private void SerializeQuestionStruct(TestQuestion question, JsonWriter json)
        {
            json.WritePropertyName("id");
            json.WriteValue(question.Id);

            json.WritePropertyName("question");
            json.WriteValue(question.Question);

	        json.WritePropertyName("correct_answer_id");
	        json.WriteValue(question.CorrectAnswerId);

            json.WritePropertyName("answers");
            json.WriteStartArray();

            foreach(var answer in question.Answers)
            {
                json.WriteValue(answer);
            }

            json.WriteEndArray();
        }

        /// <summary>
        /// This method serializes test object and returns json string response
        /// </summary>
        public override string Serialize(TestItem testItem)
        {
            if(testItem.Questions.Count == 0)
            {
                throw new ArgumentException("Error (Serializer Argument exception)\nYour test does not contain any questions!");
            }

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter json = new JsonTextWriter(new StringWriter(stringBuilder));

            json.Formatting = Formatting.Indented;

            json.WriteStartObject();
            json.WritePropertyName("test_name");
            json.WriteValue(testItem.TestName);

            json.WritePropertyName("questions");
            json.WriteStartArray();

            foreach(var question in testItem.Questions)
            {
                json.WriteStartObject();

                SerializeQuestionStruct(question, json);

                json.WriteEndObject();
            }

            json.WriteEndArray();
            json.WriteEnd();

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Deserializes questions using it's index
        /// </summary>
        /// <param name="token">Json serializer token</param>
        /// <param name="i">question index</param>
        /// <returns>TestQuestion struct object with deserialized info</returns>
        private TestQuestion DeserializeQuestionStruct(JToken token, int i)
        {
            TestQuestion question = new TestQuestion();

            var questionToken = token["questions"][i];
            question.Id = (int)questionToken["id"];
            question.Question = (string)questionToken["question"];
            question.CorrectAnswerId = (int)questionToken["correct_answer_id"];
            question.Answers = new List<string>();

            JArray answersArr = (JArray)questionToken["answers"];

            answersArr
                .ToList()
                .ForEach(item => question.Answers.Add(item.ToString()));

            return question;
        }

        /// <summary>
        /// Deserialize json string
        /// </summary>
        /// <param name="json">json string to deserialize</param>
        /// <returns>TestItem object which contains questions and test name</returns>
        public override TestItem Deserialize(string json)
        {
            JToken token = JToken.Parse(json);

            string testName = (string)token["test_name"];
            TestItem test = new TestItem(testName);

            JArray questionArr = (JArray)token["questions"];

            for (int i = 0; i < questionArr.Count; i++)
            {
                test.Questions.Add(DeserializeQuestionStruct(token, i));
            }

            return test;
        }

        public override bool IsTestValid(string testText)
        {
            return testText.Contains("test_name") && testText.Contains("questions");
        }
    }
}
