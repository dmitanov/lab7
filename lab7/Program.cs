using lab7.Handlers;
using lab7.Monitoring;
using lab7.Strategies;

namespace lab7;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var monitor = new EventMonitor();

        var consoleHandler = new ConsoleHandler(new TextFormatStrategy());
        var fileHandler = new FileHandler(new JsonFormatStrategy(), "logs/events.log");
        var emailHandler = new EmailHandler(new HtmlFormatStrategy(), "admin@example.com");

        monitor.OnMetricExceeded += consoleHandler.ProcessEvent;
        monitor.OnMetricExceeded += fileHandler.ProcessEvent;
        monitor.OnMetricExceeded += emailHandler.ProcessEvent;

        Console.WriteLine("=== Система мониторинга и оповещения ===");
        Console.WriteLine();

        monitor.CheckMetric("CPU", 55, 80);
        Console.WriteLine();

        monitor.CheckMetric("Memory", 91, 75);
        Console.WriteLine();

        monitor.CheckMetric("Network", 1200, 900);
        Console.WriteLine();

        Console.WriteLine("=== Смена стратегии у ConsoleHandler во время выполнения ===");
        consoleHandler.SetStrategy(new HtmlFormatStrategy());

        monitor.CheckMetric("CPU", 95, 80);
        Console.WriteLine();

        Console.WriteLine("Работа программы завершена.");
        Console.ReadKey();
    }
}