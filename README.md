# Uptime Kuma push health check for ASP.NET Core

- [Uptime Kuma](https://github.com/louislam/uptime-kuma)
- [Health checks in ASP.NET Core
](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks)

## How to use
1. Create monitor with `Push` Monitor type
1. Use `Push URL` without query string to add [`IHealthCheckPublisher`](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks#health-check-publisher)
    ```cs
      builder.Services.AddUptimePushCheck(new Uri("http://localhost:3001/api/push/token")); // Don't forget to remove query parameters from the URL.
    ```
