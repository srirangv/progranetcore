using chetak;
using Prometheus;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker1>();
        services.AddHostedService<Worker2>();
    })
    .Build();

var server = new MetricServer(port: 1235);
server.Start();

await host.RunAsync();
