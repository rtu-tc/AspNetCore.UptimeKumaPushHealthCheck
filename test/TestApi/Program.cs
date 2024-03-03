using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("Simple", () => new HealthCheckResult(HealthStatus.Healthy));

builder.Services.AddUptimeKumaPushCheck(new Uri("http://localhost:3001/api/push/g09QyINirn"));

var app = builder.Build();

app.MapHealthChecks("/healthz");

app.Run();
