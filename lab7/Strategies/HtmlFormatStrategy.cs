using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace lab7.Strategies
{
    public class HtmlFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            var encodedMessage = WebUtility.HtmlEncode(message);

            return $"""
                <div class="event-message">
                    <h3>Системное событие</h3>
                    <p><b>Время:</b> {timestamp:yyyy-MM-dd HH:mm:ss}</p>
                    <p><b>Сообщение:</b> {encodedMessage}</p>
                </div>
                """;
        }
    }
}
