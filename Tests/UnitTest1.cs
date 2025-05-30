using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using LoggingLib;
using ReportingLib;
using LocalizationLib;
using Xunit;

namespace Tests
{
    public class LoggerTests
    {
        [Fact]
        public void Log_WritesMessageToFile()
        {
            string path = "test_log.txt";
            var logger = new Logger(path);

            logger.Log("Test message", LogLevel.Info);

            string result = File.ReadAllText(path);
            Assert.Contains("Test message", result);

            File.Delete(path);
        }
    }

    public class ReportExporterTests
    {
        [Fact]
        public void ExportToCsv_CreatesValidCsv()
        {
            var artifacts = new List<Artifact>
            {
                new Artifact { Name = "Statue", Description = "Bronze statue", Year = 1900 }
            };
            string path = "report.csv";
            var exporter = new ReportExporter();

            exporter.ExportToCsv(artifacts, path);

            string content = File.ReadAllText(path);
            Assert.Contains("Statue,Bronze statue,1900", content);

            File.Delete(path);
        }
    }

    public class LanguageManagerTests
    {
        [Fact]
        public void GetString_ReturnsExpectedValue()
        {
            var resourceManager = new ResourceManager("Tests.TestResources", Assembly.GetExecutingAssembly());
            var manager = new LanguageManager(resourceManager);

            manager.SetCulture("en");
            var value = manager.GetString("Greeting");

            Assert.Equal("Hello", value);
        }
    }
}
