using Azure.Storage.Blobs;
using AzureIntegration_BookedReductions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Services
{
    public class BlobService : IBlobService
    {
        public async Task DeleteBlobAsync(BlobClient client)
        {
            try
            {
                await client.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BlobClient OpenBlobClient(string containerName, string blobName)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("BlobStorageConnectionString"));
                BlobContainerClient container = blobServiceClient.GetBlobContainerClient(containerName);
                container.CreateIfNotExists();
                return container.GetBlobClient(blobName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadFileToBlobAsync(BlobClient blob, byte[] filedata, string filrMimeType, string errormessage)
        {
            try
            {
                using (var ms = new MemoryStream(filedata, false))
                {
                    await blob.UploadAsync(ms, overwrite: true);
                }
                if(!string.IsNullOrWhiteSpace(errormessage))
                {
                    Dictionary<string, string> metadataProperties = new Dictionary<string, string>();
                    metadataProperties.Add("Error", errormessage);
                    await blob.SetMetadataAsync(metadataProperties);
                }
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
