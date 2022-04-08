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
        public async Task UpdateServiceBusQueue(byte[] blobUrl, Dictionary<string, string> userProps)
        {
            try
            {
                var serviceBusConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionVMS");
                var topicName = Environment.GetEnvironmentVariable("TopicNameVMS");
                await using(var client = new ServiceBusClient(serviceBusConnectionString))
                {
                    var sender = client.CreateSender(topicName);
                    var messageOutput = new ServiceBusMessage(blobUrl)
                    {
                        MessageId = Convert.ToString(Guid.NewGuid())
                    }; 
                    foreach (var prop in userProps)
                    {
                        messageOutput.ApplicationProperties.Add(prop.Key, prop.Value);
                    }

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
