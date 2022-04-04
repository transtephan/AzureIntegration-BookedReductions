using AzureIntegration_BookedReductions.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Services
{
    public class BookedReductionsKLService : IBookedReductionsKLService
    {
        public async Task DeliveryTransferProcessMsg(string queueItem, ILogger log)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessMsg(Message queueItem, ILogger log)
        {
            throw new NotImplementedException();
        }

        public async Task ReProcessMsg(Stream blobItem, string fileName, ILogger log)
        {
            throw new NotImplementedException();
        }
    }
}
