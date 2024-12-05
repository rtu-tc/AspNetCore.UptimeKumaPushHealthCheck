using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Globalization;

namespace RTU_TC.AspNetCore.UptimeKumaPushHealthCheck;

public sealed class UptimeKumaHealthCheckPublisher(HttpClient httpClient) : IHealthCheckPublisher
{
    public async Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync($"?status={(report.Status == HealthStatus.Healthy ? "up" : "down")}&msg={Uri.EscapeDataString(report.Status.ToString())}&ping={report.TotalDuration.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}