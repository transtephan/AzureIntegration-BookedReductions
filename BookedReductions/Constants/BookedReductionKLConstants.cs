using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Constants
{
    public class BookedReductionKLConstants
    {
        public const string blobInContainerName = "bookedreduction-claimcheck-in";
        public const string blobOutContainerName = "bookedreduction-claimcheck-out";
        public const string blobReProcessContainerName = "bookedreduction-reprocess";
        public const string blobContainerName = "bookedreduction";
        public const string version = "1.0";
        public const string intDefault = "0";
        public const string decimalDefault = "0.0";

        public static string GetBlobFileName(string blobFileLocation)
        {
            return (!string.IsNullOrEmpty(blobFileLocation) && blobFileLocation.Contains(blobInContainerName)) ?
                    blobFileLocation.Split(blobInContainerName)[1] : blobFileLocation;
        }
    }
}
