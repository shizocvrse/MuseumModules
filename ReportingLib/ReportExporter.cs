using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReportingLib
{
    public class Artifact
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
    }

    public class ReportExporter
    {
        public void ExportToCsv(List<Artifact> artifacts, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Name,Description,Year");

            foreach (var artifact in artifacts)
                sb.AppendLine($"{artifact.Name},{artifact.Description},{artifact.Year}");

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}