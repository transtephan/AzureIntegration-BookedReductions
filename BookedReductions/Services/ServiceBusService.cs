using Azure.Messaging.ServiceBus;
using AzureIntegration_BookedReductions.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Services
{
    public class ServiceBusService : IServiceBusService
    {
        public async Task UpdateServiceBusQueue(Message queueItem, ILogger log)
        {
            try
            {
                var serviceBusConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionVMS");
                var topicName = Environment.GetEnvironmentVariable("TopicNameVMS");
                await using(var client = new ServiceBusClient(serviceBusConnectionString))
                {
                    var sender = client.CreateSender(topicName);
                    var messageOutput = new ServiceBusMessage(queueItem.ToString());
                   
                    await sender.SendMessageAsync(messageOutput);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
