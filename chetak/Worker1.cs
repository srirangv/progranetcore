using Prometheus;

namespace chetak;

public class Worker1 : BackgroundService
{
    private readonly ILogger<Worker1> _logger;

    private static readonly Counter TickTock =
        Metrics.CreateCounter("worker1_ticks_total", "Just keeps on ticking");


    public Worker1(ILogger<Worker1> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            TickTock.Inc();

            _logger.LogInformation("Worker running at: {time} & {count}", DateTimeOffset.Now, TickTock.Value);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
