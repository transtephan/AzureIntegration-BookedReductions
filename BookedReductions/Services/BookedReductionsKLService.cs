using Azure.Messaging.ServiceBus;
using AzureIntegration_BookedReductions.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AzureIntegration_BookedReductions.Services;

namespace AzureIntegration_BookedReductions.Services
{
    public class BookedReductionsKLService : IBookedReductionsKLService
    {
        private readonly ILogger _log;
        private readonly IBlobService _blobService;
        public BookedReductionsKLService(ILogger<BookedReductionsKLService> log, IBlobService blobService)
        {
            _log = log;
            _blobService = blobService;
        }

        public async Task ProcessMsg(Message queueItem, ILogger log)
        {
            //IDictionary<string, object> messageProperties = queueMsg.UserProperties;
            //var blobUri = messageProperties.ContainsKey("BlobUri") == true ? messageProperties["BlobUri"].ToString(): "";
            //log.LogInformation("Blob URI received from SB Queue");
            
           UpdateServiceBusQueue(queueItem, log);

        }
        public async Task DeliveryTransferProcessMsg(string queueItem, ILogger log)
        {
            throw new NotImplementedException();
        }

        public async Task ReProcessMsg(Stream blobItem, string fileName, ILogger log)
        {
            throw new NotImplementedException();
        }
    }
}
