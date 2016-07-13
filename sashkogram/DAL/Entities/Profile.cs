using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileStatus { get; set; }

        public ICollection<Photo> Avatars { get; set; }
        public ICollection<Photo> ProfilePhotos { get; set; }
        //public List<Profile> Followers { get; set; }
        //public List<Profile> Following { get; set; }

        public Profile()
        {
            Avatars = new List<Photo>();
            ProfilePhotos = new List<Photo>();
            //Followers = new List<Profile>();
            //Following = new List<Profile>();
        }
    }
}
