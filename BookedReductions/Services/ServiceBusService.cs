using AzureIntegration_BookedReductions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Services
{
    public class ServiceBusService : IServiceBusService
    {
        public async Task UpdateServiceBusQueue(byte[] blobUrl, Dictionary<string, string> userProps)
        {
            throw new NotImplementedException();
        }
    }
}
