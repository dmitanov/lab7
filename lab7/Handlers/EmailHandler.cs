using lab7.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Handlers
{
    public class EmailHandler : EventHandlerBase
    {
        private readonly string _emailAddress;

        public EmailHandler(IFormatStrategy strategy, string emailAddress) : base(strategy)
        {
            _emailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        }

        protected override void SendMessage(string message)
        {
            Console.WriteLine("----- EmailHandler (имитация) -----");
            Console.WriteLine($"Отправка письма на: {_emailAddress}");
            Console.WriteLine(message);
            Console.WriteLine("-----------------------------------");
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[EmailHandler] Письмо отправлено (имитация) на {_emailAddress}");
        }
    }
}
