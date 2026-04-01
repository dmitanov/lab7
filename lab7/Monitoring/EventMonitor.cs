using lab7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab7.Monitoring
{
    public class EventMonitor
    {
        public event MetricEventHandler? OnMetricExceeded;

        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"[Monitor] Проверка {metricName}: значение={value}, порог={threshold}");

            if (value > threshold)
            {
                var eventData = new MetricData(
                    metricName: metricName,
                    value: value,
                    threshold: threshold,
                    timestamp: DateTime.Now
                );

                OnMetricExceeded?.Invoke(
                    new MetricEventArgs(
                        eventType: $"{metricName}_Exceeded",
                        data: eventData
                    )
                );
            }
            else
            {
                Console.WriteLine($"[Monitor] Метрика {metricName} в норме.");
            }
        }
    }
}
