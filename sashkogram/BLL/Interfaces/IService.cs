using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService
    {
        IEnumerable<PhotoDTO> GetAllPhotoFromProfile(int profileId); //yes
        ProfileDTO GetProfile(int id); //yes
        PhotoDTO GetPhoto(int id); //yes
        void AddPhotoToProfile(PhotoDTO item, int profileId); //yes
        void UpdateProfile(ProfileDTO item);
        void DeletePhoto(int id); 
        void Dispose(); //yes

        void AddAvatarToProfile(PhotoDTO item, int profileId); 
        void ChangeProfileStatus(ProfileDTO profile);
    }
}
