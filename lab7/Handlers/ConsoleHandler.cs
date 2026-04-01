using lab7.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Handlers
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy)
        {
        }

        protected override void SendMessage(string message)
        {
            Console.WriteLine("----- ConsoleHandler -----");
            Console.WriteLine(message);
            Console.WriteLine("--------------------------");
        }

        protected override void LogResult()
        {
            Console.WriteLine("[ConsoleHandler] Сообщение выведено в консоль.");
        }
    }
}
