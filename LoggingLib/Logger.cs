using System;
using System.IO;

namespace LoggingLib
{
    public enum LogLevel { Info, Warning, Error }

    public class Logger
    {
        private readonly string _filePath;

        public Logger(string filePath = "log.txt")
        {
            _filePath = filePath;
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logEntry = $"{DateTime.Now:G} [{level}] {message}";
            File.AppendAllText(_filePath, logEntry + Environment.NewLine);
        }
    }
}