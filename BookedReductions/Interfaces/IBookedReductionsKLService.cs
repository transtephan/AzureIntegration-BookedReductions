using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Interfaces
{
    public interface IBookedReductionsKLService
    {
        Task ProcessMsg(Message queueItem, ILogger log);
        Task DeliveryTransferProcessMsg(string queueItem, ILogger log);
        Task ReProcessMsg(Stream blobItem, string fileName, ILogger log);
    }
}
