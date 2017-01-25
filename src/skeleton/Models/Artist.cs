using System.Collections.Generic;

namespace skeleton.Models {
    public class Artist {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CV { get; set; }
        public string PortraitImgUrl { get; set; }
        public string FrontPageImgUrl { get; set; }
        public List<string> ImgUrls { get; set; }
    }
}