using lab7.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Handlers
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        protected override void SendMessage(string message)
        {
            var directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.AppendAllText(_filePath, message + Environment.NewLine + Environment.NewLine);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[FileHandler] Сообщение записано в файл: {_filePath}");
        }
    }
}
