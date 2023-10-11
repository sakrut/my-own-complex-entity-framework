﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OwnComplex.Domain.Repositories;
using OwnComplex.Domain.Service;
using OwnComplex.EF7;
using OwnComplex.EF7.OwnModel;
using ILogger = OwnComplex.Domain.Service.ILogger;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder => { })
    .ConfigureLogging((c, b) =>
    {
        b.AddSimpleConsole(o =>
        {
            o.IncludeScopes = false;
            o.SingleLine = true;
            o.TimestampFormat = "HH:mm:ss ";
        });
        b.AddDebug();
        b.AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning)
            .AddFilter("NToastNotify", LogLevel.Warning);
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<ILogger, Logger>();
        services.AddDbContext<TestEF7Context>(ServiceLifetime.Scoped, ServiceLifetime.Scoped);
        services.AddScoped<IPeopleRepository>(provider => provider.GetRequiredService<TestEF7Context>());
        services.AddScoped<IPeopleService, PeopleService>();
        services.AddSingleton<ExampleService>();
        services.AddSingleton<ITenantIdAccessor, TenantIdAccessor>();
        services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();