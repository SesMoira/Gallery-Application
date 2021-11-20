using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImagePlatform.Models
{
    public partial class ImageData
    {
        public int ImageId { get; set; }
        [DisplayName("Image Title")]
        public string ImageTitle { get; set; }
        [DisplayName("Captured By")]
        public string CapturedBy { get; set; }
        [DisplayName("Date Captured")]
        public DateTime? CapturedDate { get; set; }
        [DisplayName("Location")]
        public string Geolocation { get; set; }
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
        [DisplayName("Image Description")]
        public string ImageDescription { get; set; }
        [DisplayName("Image Tag")]
        public string ImageTags { get; set; }
    }
}
