using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePlatform.Repository
{
    public class ImageStorageRepository
    {
        public string ReadImageFromBlob(string filename)
        {
            string connectionstring = "";
            string container = "ImagePlatform";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionstring, container);
            var blob = blobContainerClient.GetBlobClient(filename);

            string filePath = @$"C:\Users\izwelethu\Desktop\Project2\ImagePlatform\ImagePlatform\wwwroot\Images\Temp\{filename}";

            blob.DownloadTo(filePath);

            return filePath;
        }

        public string WriteImageToBlob(string filePath, string filename)
        {
            string connectionstring = "";
            string container = "ImagePlatform";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionstring, container);


            StreamReader Sr = new StreamReader(filePath);


            blobContainerClient.UploadBlob(filename, Sr.BaseStream);

            return blobContainerClient.Uri.ToString();
        }
    }
}
