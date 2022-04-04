using Azure.Storage.Blobs;
using AzureIntegration_BookedReductions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Services
{
    public class BlobService : IBlobService
    {
        public async Task DeleteBlobAsync(BlobClient client)
        {
            throw new NotImplementedException();
        }

        public BlobClient OpenBlobClient(string containerName, string blobName)
        {
            throw new NotImplementedException();
            
        }

        public async Task<string> UploadFileToBlobAsync(BlobClient blob, byte[] filedata, string filrMimeType, string errormessage)
        {
            throw new NotImplementedException();
        }
    }
}
