using System.IO;
using System.Linq;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeacherWorkout.Specs.Extensions
{
    public static class FluentExtensions
    {
        public static void MatchResponse(this ObjectAssertions assertions, string path)
        {
            var generateNew = !GlobalSettings.IsCi;
            var actual = assertions.Subject;

            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(path))
                .FailWith("You need to pass in a path to a sample response")
                .Then
                .ForCondition(File.Exists(path) || generateNew)
                .FailWith("Sample does not exist");
            
            if (!File.Exists(path) && generateNew)
            {
                var currentNamespace = "TeacherWorkout.Specs";
                var currentDirectoryPath = Directory.GetCurrentDirectory();
                var targetFilePath = Path.Join(currentDirectoryPath.Split(currentNamespace).First(), currentNamespace, path);
                var targetDirectoryPath = Path.GetDirectoryName(targetFilePath);

                if (!Directory.Exists(targetDirectoryPath))
                {
                    Directory.CreateDirectory(targetDirectoryPath);    
                }
                
                File.WriteAllText(targetFilePath, actual.ToJson());
                path = targetFilePath;
            }
            
            var expectedToken = JToken.Parse(File.ReadAllText(path));
            assertions.Subject.ToJToken().Should().BeEquivalentTo(expectedToken);
        }

        private static JToken ToJToken(this object obj)
        {
            return JToken.Parse(obj.ToJson());
        }

        public static string ToJson(this object obj)
        {
            dynamic parsedJson = obj is string s ? JsonConvert.DeserializeObject(s) : obj;
            
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}