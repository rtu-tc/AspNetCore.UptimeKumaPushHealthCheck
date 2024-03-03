using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Globalization;

namespace RTU_TC.AspNetCore.UptimeKumaPushHealthCheck;

public sealed class UptimeKumaHealthCheckPublisher(HttpClient httpClient) : IHealthCheckPublisher
{
    public async Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
    {
        var query = new QueryString()
            .Add("status", report.Status == HealthStatus.Healthy ? "up" : "down")
            .Add("msg", report.Status.ToString())
            .Add("ping", report.TotalDuration.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
        await httpClient.GetAsync(query.ToUriComponent(), cancellationToken);
    }
}