using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileStatus { get; set; }

        public ICollection<PhotoDTO> Avatars { get; set; }
        public ICollection<PhotoDTO> ProfilePhotos { get; set; }

        public ProfileDTO()
        {
            ProfilePhotos = new List<PhotoDTO>();
            Avatars = new List<PhotoDTO>();
        }
        //public List<ProfileDTO> Followers { get; set; }
        //public List<ProfileDTO> Following { get; set; }
    }
}
