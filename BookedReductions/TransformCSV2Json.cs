using AzureIntegration_BookedReductions.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions
{
    public class TransformCSV2Json
    {
        private readonly IBookedReductionsKLService _bookedReductionsKLService;
        public TransformCSV2Json(IBookedReductionsKLService bookedReductionsKLService)
        {
            _bookedReductionsKLService = bookedReductionsKLService;
        }

        [FunctionName("Function1")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "BlobStorageConnectionString")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    

        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("QueueNameVMS", Connection = "ServiceBusConnectionVMS")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

    }
}
