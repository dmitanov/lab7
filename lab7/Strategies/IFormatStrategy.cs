using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Strategies
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }
}
