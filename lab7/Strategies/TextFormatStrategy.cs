using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Strategies
{
    public class TextFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {message}";
        }
    }
}
