using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using WorkerService;

// Use PowerShell command to run windows service

// sc.exe create ".NET6 Timer Windows Service" binpath="...\WorkerService.exe"
// sc.exe start ".NET6 Timer Windows Service"
// sc.exe stop ".NET6 Timer Windows Service"
// sc.exe delete ".NET6 Timer Windows Service"

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET6 Timer Windows Service";
    })
    .ConfigureServices(services =>
    {
        LoggerProviderOptions.RegisterProviderOptions<
            EventLogSettings, EventLogLoggerProvider>(services);

        // Add services to container here...

        services.AddHostedService<Worker>();
    })
    .ConfigureLogging((context, logging) =>
    {
        // See: https://github.com/dotnet/runtime/issues/47303
        logging.AddConfiguration(
            context.Configuration.GetSection("Logging"));
    })
    .Build();

await host.RunAsync();