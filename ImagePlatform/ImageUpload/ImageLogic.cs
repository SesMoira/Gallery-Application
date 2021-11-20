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
        public bool UploadImage(ImageData ImageDataModel)
        {
            try
            {
                ImageStorageRepository.writeImageToBlob

            }
            else(Exception)
            {
                return false;
            }
            
        }
    }
}
