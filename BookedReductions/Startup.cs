using AzureIntegration_BookedReductions.Interfaces;
using AzureIntegration_BookedReductions.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(AzureIntegration_BookedReductions.Startup))]
namespace AzureIntegration_BookedReductions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddScoped<IBookedReductionsKLService, BookedReductionsKLService>();
            //builder.Services.AddScoped<IBlobService, BlobService>();
            builder.Services.AddScoped<IServiceBusService, ServiceBusService>();
        }
    }
}
