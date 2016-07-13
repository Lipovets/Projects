using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sashkogram.Models
{
    public class ProfileViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileStatus { get; set; }

        public ICollection<PhotoViewModel> Avatars { get; set; }
        public ICollection<PhotoViewModel> ProfilePhotos { get; set; }

        public ProfileViewModel()
        {
            Avatars = new List<PhotoViewModel>();
            ProfilePhotos = new List<PhotoViewModel>();
        }

        //public List<ProfileViewModel> Followers { get; set; }
        //public List<ProfileViewModel> Following { get; set; }
    }
}