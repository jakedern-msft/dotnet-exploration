using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(options =>
    {
        options.AddConsoleExporter();
        options.IncludeScopes = true;
    });
});

var logger = loggerFactory.CreateLogger<Program>();
using(logger.BeginScope(new List<KeyValuePair<string, object>>
{
    new KeyValuePair<string, object>("scope_name", "parent"),
}))
{
    int id = 0;
    while(true)
    {
        logger.LogInformation(eventId: id++, "Doing some structured things {foo}", "bar");
        await Task.Delay(1000);
    }
}
