using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sashkogram.Models
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int LikeNumber { get; set; }
        public List<string> Comment { get; set; }
        public byte[] Image { get; set; }

        public int? ProfileViewModelId { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }
    }
}