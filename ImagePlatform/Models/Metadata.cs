using System;
using System.Collections.Generic;

namespace ImagePlatform.Models
{
    public partial class Metadata
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string CapturedBy { get; set; }
        public string CapturedDate { get; set; }
        public string Geolocation { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
    }
}
