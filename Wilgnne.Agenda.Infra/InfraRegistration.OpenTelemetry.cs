using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Wilgnne.Agenda.Infra
{
    public partial class InfraRegistration
    {
        private static IServiceCollection AddOpenTelemetryService(this IServiceCollection services)
        {
            const string serviceName = "agenda-api";

            services.AddOpenTelemetry()
              .ConfigureResource(resource => resource.AddService(serviceName))
              .WithTracing(tracing => tracing
                  .AddAspNetCoreInstrumentation()
                  .AddConsoleExporter()
                  .AddZipkinExporter(o =>
                  {
                      o.HttpClientFactory = () =>
                      {
                          var client = new HttpClient();
                          client.DefaultRequestHeaders.Add("X-MyCustomHeader", serviceName);
                          return client;
                      };

                      o.Endpoint = new Uri("http://zipkin:9411/api/v2/spans");
                  }))
              .WithMetrics(metrics => metrics
                  .AddAspNetCoreInstrumentation()
                  .AddConsoleExporter());

            return services;
        }

        private static ILoggingBuilder AddOpenTelemetryLoggings(this ILoggingBuilder logging)
        {
            const string serviceName = "agenda-api";

            return logging.AddOpenTelemetry(options =>
            {
                options
                    .SetResourceBuilder(
                        ResourceBuilder.CreateDefault()
                            .AddService(serviceName))
                    .AddConsoleExporter();
            });
        }
    }
}
