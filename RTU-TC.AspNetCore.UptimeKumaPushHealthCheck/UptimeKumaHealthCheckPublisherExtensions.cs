using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RTU_TC.AspNetCore.UptimeKumaPushHealthCheck;

public static class UptimeKumaHealthCheckPublisherExtensions
{
    public static IServiceCollection AddUptimePushCheck(this IServiceCollection services, Uri uptimePushUriPush)
    {
        services.AddHttpClient<IHealthCheckPublisher, UptimeKumaHealthCheckPublisher>(client => client.BaseAddress = uptimePushUriPush);
        return services;
    }
}
