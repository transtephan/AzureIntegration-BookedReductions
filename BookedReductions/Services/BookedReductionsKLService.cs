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
using AzureIntegration_BookedReductions.Constants;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage.Blobs.Specialized;

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

        public async Task ProcessMsg(Message queueMsg, ILogger log)
        {
            string msgcontent = string.Empty;
            IDictionary<string, object> messageProperties = queueMsg.UserProperties;
            var blobUri = messageProperties.ContainsKey("BlobUri") == true ? messageProperties["BlobUri"].ToString(): "";
            log.LogInformation("Blob URI received from SB Queue");
            if (!string.IsNullOrWhiteSpace(blobUri))
                msgcontent = await GetMessageFromBlobContainer(fileName: BookedReductionKLConstants.GetBlobFileName(blobUri), log);
            else
                msgcontent = Encoding.UTF8.GetString(queueMsg.Body);
            await BookedReductionsProcessMsg(msgcontent, log);


        }
        public async Task BookedReductionsProcessMsg(string queueItem, ILogger log)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task ReProcessMsg(Stream blobItem, string fileName, ILogger log)
        {
            try
            {
                StreamReader reader = new StreamReader(blobItem);
                string msgcontent = reader.ReadToEnd();
                ////Delete the blob.
                BlobClient blobClient = _blobService.OpenBlobClient(BookedReductionKLConstants.blobReProcessContainerName, fileName);
                await _blobService.DeleteBlobAsync(blobClient);
                ////Process the blob.
                await BookedReductionsProcessMsg(msgcontent, log);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> GetMessageFromBlobContainer(string fileName, ILogger log)
        {
            try
            {
                BlobClient blobClient = _blobService.OpenBlobClient(BookedReductionKLConstants.blobInContainerName, fileName);
                var blobContent = await blobClient.DownloadStreamingAsync();
                string themessage = "";
                using (var reader = new StreamReader(blobContent.Value.Content))
                {
                    themessage = reader.ReadToEnd();
                }
                await _blobService.DeleteBlobAsync(blobClient);
                return themessage;

            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error in GetMessageFromBlobContainer. " + ex.Message);
                throw ex;
            }
        }
        private async Task<string> ProcessBlob(string containerName, string folderName, string fileName, byte[] fileData, string fileMimeType, ILogger log, string errorMsg)
        {
            try
            {
                var now = DateTime.Now;
                var extendedFileName = now.Year + "/" + now.Month + "/" + now.Day + "/" + fileName;
                //Choose "folder" to write the blob to.
                if (!string.IsNullOrWhiteSpace(folderName))
                {
                    fileName = $"{folderName}/{extendedFileName}";
                }
                else
                {
                    fileName = extendedFileName;
                }
                BlobClient blobClient = _blobService.OpenBlobClient(containerName, fileName);
                await _blobService.UploadFileToBlobAsync(blobClient, fileData, fileMimeType, errorMsg);
                Uri blobUrl = GetServiceSasUriForBlob(blobClient, null);
                return blobUrl.ToString();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error in UploadFileToBlobAsync. Could not upload" + fileName + " to container "
                    + containerName + ". Exception: " + ex.Message);
                throw ex;
            }
        }
        private static Uri GetServiceSasUriForBlob(BlobClient blobClient, string storedPolicyName = null)
        {
            try
            {
                // Check whether this BlobClient object has been authorized with Shared Key.
                if (blobClient.CanGenerateSasUri)
                {
                    // Create a SAS token that's valid for 3 days.
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                        BlobName = blobClient.Name,
                        Resource = BookedReductionKLConstants.blobOutContainerName
                    };

                    if (storedPolicyName == null)
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(3);
                        sasBuilder.SetPermissions(BlobSasPermissions.Read);
                    }
                    else
                    {
                        sasBuilder.Identifier = storedPolicyName;
                    }

                    Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
                    return sasUri;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
