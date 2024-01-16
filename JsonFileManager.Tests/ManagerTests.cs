using FluentAssertions;
using Newtonsoft.Json;

namespace JsonFileManager.Tests
{
    public class ManagerTests
    {
        // Har en dictionary, får JSON tillbaka
        [Fact]
        public void CreateJsonFromDict_ShouldReturnJson()
        {
            // Given
            Dictionary<string, object> dict = new()
            {
                // { "key", "value" }
                { "name", "Gandalf" },
                { "Age", 3000 },
                { "Profession", "Wizard" }
            };
            Manager manager = new();
            // When
            string expectedJson = JsonConvert.SerializeObject(dict);
            string actualJson = manager.CreateJsonFromDict(dict);

            // Then
            actualJson.Should().NotBeNull();
            actualJson.Should().BeEquivalentTo(expectedJson);
        }

        [Fact]

        public void CreateJsonFromDict_EmptyDict_ShouldThrowArgumentException()
        {
            // Given
            Dictionary<string, object> dict = new();
            Manager manager = new();
            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateJsonFromDict_NullDict_ShouldThrowArgumentNullException()
        {
            // Given
            Dictionary<string, object>? dict = null;
            Manager manager = new();
            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateJsonFromDict_NullValue_ShouldThrowNullReferenceException()
        {
            // Given
            Dictionary<string, object> dict = new()
            {
                { "name", null }
            };
            Manager manager = new();
            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void WriteJsonFile_ValidJson_ShouldWriteJsonFile()
        {
            // Given
            object obj = new { Name = "Gandalf", Age = 30, Profession = "Wizard" };
            string json = JsonConvert.SerializeObject(obj);
            string fileName = "test.json";
            Manager manager = new();
            // When
            manager.WriteJsonFile(json, fileName);

            // Then
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            string fileContent = File.ReadAllText(filePath);
            fileContent.Should().BeEquivalentTo(json);
        }

        [Fact]
        public void WriteJsonFile()
        {
            // Given
            string invalidJson = "invalid json";
            string fileName = "test.json";
            Manager manager = new();
            // When
            Action test = () => manager.WriteJsonFile(invalidJson, fileName);

            // Then
            test.Should().Throw<JsonReaderException>();
        }

    }
}
