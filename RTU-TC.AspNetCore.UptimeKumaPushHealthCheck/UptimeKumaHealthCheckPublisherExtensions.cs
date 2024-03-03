using Microsoft.Extensions.Diagnostics.HealthChecks;
using RTU_TC.AspNetCore.UptimeKumaPushHealthCheck;

namespace Microsoft.Extensions.DependencyInjection;

public static class UptimeKumaHealthCheckPublisherExtensions
{
    public static IServiceCollection AddUptimePushCheck(this IServiceCollection services, Uri uptimePushUriPush)
    {
        services.AddHttpClient<IHealthCheckPublisher, UptimeKumaHealthCheckPublisher>(client => client.BaseAddress = uptimePushUriPush);
        return services;
    }
}
