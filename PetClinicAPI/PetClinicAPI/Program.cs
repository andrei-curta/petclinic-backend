using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;

namespace PetClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                    config.AddAzureKeyVault(
                        keyVaultEndpoint,
                        new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                            .ConfigureLogging(
                                builder =>
                                {
                                    // Providing an instrumentation key here is required if you're using
                                    // standalone package Microsoft.Extensions.Logging.ApplicationInsights
                                    // or if you want to capture logs from early in the application startup
                                    // pipeline from Startup.cs or Program.cs itself.
                                    builder.AddApplicationInsights("dafb41aa-fcf7-40a2-a962-4ea2b63f7fbc");

                                    // Optional: Apply filters to control what logs are sent to Application Insights.
                                    // The following configures LogLevel Information or above to be sent to
                                    // Application Insights for all categories.
                                    // builder
                                    //     .AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.
                                    //             ApplicationInsightsLoggerProvider>
                                    //         ("", LogLevel.Information);
                                });
                    }
                );
    }
}