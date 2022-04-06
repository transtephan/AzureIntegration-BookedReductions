using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Interfaces
{
    public interface IServiceBusService
    {
        //Task UpdateServiceBusQueue(byte[] blobUrl, Dictionary<string, string> userProps); 
        Task UpdateServiceBusQueue(Message queueItem, ILogger log);
    }
}
