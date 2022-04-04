using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Interfaces
{
    public interface IBlobService
    {
        BlobClient OpenBlobClient(string containerName, string blobName);
        Task<string> UploadFileToBlobAsync(BlobClient blob, byte[] filedata, string filrMimeType, string errormessage);
        Task DeleteBlobAsync(BlobClient client);

    }
}
