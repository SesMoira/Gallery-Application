using ImagePlatform.Models;
using ImagePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePlatform.ImageUpload
{
    public class ImageLogic
    {
        public async Task<bool> UploadImage(ImageData ImageModel, Metadata MetadataModel, string filepath)
        {
            ImageStorageRepository imageStorageRepository = new ImageStorageRepository();
            ImageRepository imageRepository = new ImageRepository();

            try
            {
                var filepathSplit = filepath.Split("\\");
                //string filename = new filepathSplit[filepathSplit.Length - 1];

                //string blobURL = ImageStorageRepository.WriteImageToBlob(filepath,filename);

                //bool result = await ImageRepository.CreateImageAsync(ImageModel);
                //return bool result;

            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
