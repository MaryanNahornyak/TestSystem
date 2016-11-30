using System;
using System.Collections;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace TestingSystemApi.Serializer
{
    public sealed class JsonTestSerializer : TestSystemSerialization
    {
        public JsonTestSerializer(TestItem testItem)
            : base(testItem)
        {}

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

            json.WritePropertyName("answers");
            json.WriteStartArray();

            foreach(var answer in question.Answers)
            {
                json.WriteValue(answer);
            }

            json.WriteEndArray();
        }

        /// <summary>
        /// This class serializes test object and returns json string response
        /// </summary>
        public override string Serialize()
        {
            if(this.TestItem.Questions.Count == 0)
            {
                throw new ArgumentException("Error (Serializer Argument exception)\nYour test does not contain any questions!");
            }

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter json = new JsonTextWriter(new StringWriter(stringBuilder));

            json.Formatting = Formatting.Indented;

            json.WriteStartObject();
            json.WritePropertyName("test_name");
            json.WriteValue(this.TestItem.TestName);

            json.WritePropertyName("questions");
            json.WriteStartArray();

            foreach(var question in this.TestItem.Questions)
            {
                json.WriteStartObject();

                SerializeQuestionStruct(question, json);

                json.WriteEndObject();
            }

            json.WriteEndArray();
            json.WriteEnd();

            return stringBuilder.ToString();
        }
    }
}
