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
        Task UpdateServiceBusTopic(byte[] blobUrl, Dictionary<string, string> userProps); 

    }
}
