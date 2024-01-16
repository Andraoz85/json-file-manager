using Newtonsoft.Json;

namespace JsonFileManager
{
    public class Manager
    {
        // Json till Dictionary

        // Dictionary till Json
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            if (!dict.Any())
                throw new ArgumentException();

            return JsonConvert.SerializeObject(dict);
        }


        // Läsa Json-fil

        // Skriva Json-fil

    }
}
