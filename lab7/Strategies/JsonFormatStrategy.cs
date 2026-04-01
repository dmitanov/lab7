using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace lab7.Strategies
{
    public class JsonFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            var obj = new
            {
                timestamp = timestamp.ToString("O"),
                message = message
            };

            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
