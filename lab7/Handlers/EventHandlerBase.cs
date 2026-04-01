using lab7.Models;
using lab7.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Handlers
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy;

        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data);
            SendMessage(message);
            LogResult();
        }

        protected virtual string FormatMessage(string type, MetricData data)
        {
            string rawMessage =
                $"Событие: {type}; Метрика: {data.MetricName}; Значение: {data.Value}; Порог: {data.Threshold}";

            return _formatStrategy.Format(rawMessage, data.Timestamp);
        }

        protected abstract void SendMessage(string message);

        protected virtual void LogResult()
        {
            Console.WriteLine($"[{GetType().Name}] Обработка завершена.");
        }
    }
}
