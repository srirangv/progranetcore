﻿using Prometheus;
using System;
using System.Threading;

class Program
{
    private static readonly Counter TickTock =
        Metrics.CreateCounter("sampleapp_ticks_total", "Just keeps on ticking");

    static void Main()
    {
        var server = new MetricServer(port: 1234);
        server.Start();

        while (true)
        {
            TickTock.Inc();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}