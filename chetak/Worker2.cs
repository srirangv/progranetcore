using Prometheus;

namespace chetak;

public class Worker2 : BackgroundService
{
    private readonly ILogger<Worker2> _logger;

    private static readonly Counter TickTock =
        Metrics.CreateCounter("worker2_ticks_total", "Just keeps on ticking");


    public Worker2(ILogger<Worker2> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            TickTock.Inc();

            _logger.LogInformation("Worker running at: {time} & {count}", DateTimeOffset.Now, TickTock.Value);
            await Task.Delay(3000, stoppingToken);
        }
    }
}
