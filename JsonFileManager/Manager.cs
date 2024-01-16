using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFileManager
{
    public class Manager
    {
        // Json till Dictionary

        // Dictionary till Json
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            // Guard clauses
            if (dict == null)
                throw new ArgumentNullException();
            else if (!dict.Any())
                throw new ArgumentException();
            else if (dict.Values.Any(x => x == null))
                throw new NullReferenceException();
            return JsonConvert.SerializeObject(dict);
        }


        // Läsa Json-fil

        // Skriva Json-fil


        // WriteJsonToFile
        public void WriteJsonFile(string json, string fileName)
        {
            if (IsValidJson(json))
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                File.WriteAllText(filePath, json);
            }

        }

        /// <summary>
        /// Validates a string as json. If the string is not valid, an exception is thrown.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Returns true if the input string is correct Json, otherwise this method Throws a JsonReaderException.</returns>
        /// <exception cref="JsonReaderException"></exception>
        private bool IsValidJson(string json)
        {
            JToken.Parse(json);
            return true;
        }

    }
}
