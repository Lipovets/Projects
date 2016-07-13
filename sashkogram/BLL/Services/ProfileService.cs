using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileService : IService
    {
        private IUnitOfWork Database;

        public ProfileService(IUnitOfWork data)
        {
            this.Database = data;
        }

        public IEnumerable<PhotoDTO> GetAllPhotoFromProfile(int profileId)  //получить все фото профиля
        {
            DAL.Entities.Profile profile = Database.Profiles.Get(profileId);
            IEnumerable<Photo> photos = profile.ProfilePhotos;
            Mapper.CreateMap<IEnumerable<Photo>, IEnumerable<PhotoDTO>>();
            return Mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoDTO>>(photos);
        }

        public PhotoDTO GetPhoto(int photoId) //получить фото по ІД
        {
            Photo photo = Database.Photos.Get(photoId);
            Mapper.CreateMap<Photo, PhotoDTO>();
            PhotoDTO photoDTO = Mapper.Map<Photo, PhotoDTO>(photo);
            return photoDTO;
        }

        public void AddPhotoToProfile(PhotoDTO photo, int profileId) // добавить фото в профиль соотв ІД
        {
            DAL.Entities.Profile profile = Database.Profiles.Get(profileId);
            Mapper.CreateMap<PhotoDTO, Photo>()
                .ForMember("ProfileId", c => c.MapFrom(k => k.ProfileDTOId));
            Photo dalPhoto = Mapper.Map<PhotoDTO, Photo>(photo);
            dalPhoto.Time = DateTime.Now;
            profile.ProfilePhotos.Add(dalPhoto);
            Database.Save();
        }

        public void UpdateProfile(ProfileDTO item) // dodelat'
        {
            DAL.Entities.Profile profile = Database.Profiles.Get(item.Id);
            Mapper.CreateMap<ProfileDTO, DAL.Entities.Profile>();
            profile = Mapper.Map<ProfileDTO, DAL.Entities.Profile>(item);
            //Database.Profiles.Update()
        }

        public void DeletePhoto(int id)
        {
            throw new NotImplementedException();
        }

        public ProfileDTO GetProfile(int id)
        {
            DAL.Entities.Profile profile = Database.Profiles.Get(id);
            AutoMapper.Mapper.CreateMap<DAL.Entities.Profile, ProfileDTO>()
                .ForMember(dest => dest.ProfilePhotos, opt => opt.Ignore())
                .ForMember(dest => dest.Avatars, opt => opt.Ignore());
            ProfileDTO profileDTO = Mapper.Map<DAL.Entities.Profile, ProfileDTO>(profile);

            foreach (Photo item in profile.ProfilePhotos)
            {
                profileDTO.ProfilePhotos.Add(new PhotoDTO() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileDTOId = item.ProfileId });
            }

            foreach (Photo item in profile.Avatars)
            {
                profileDTO.Avatars.Add(new PhotoDTO() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileDTOId = item.ProfileId });
            }
            return profileDTO;
        }

        public void AddAvatarToProfile(PhotoDTO photo, int profileId)
        {
            DAL.Entities.Profile profile = Database.Profiles.Get(profileId);
            Mapper.CreateMap<PhotoDTO, Photo>()
                .ForMember("ProfileId", c => c.MapFrom(k => k.ProfileDTOId));
            Photo dalPhoto = Mapper.Map<PhotoDTO, Photo>(photo);
            dalPhoto.Time = DateTime.Now;
            profile.Avatars.Add(dalPhoto);//.Insert(0, dalPhoto);
            Database.Save();
        }

        public void ChangeProfileStatus(ProfileDTO profile)
        {
            DAL.Entities.Profile prof = Database.Profiles.Get(profile.Id);
            Mapper.CreateMap<DAL.Entities.Profile, ProfileDTO>();
            ProfileDTO dto = Mapper.Map<DAL.Entities.Profile, ProfileDTO>(prof); 
            prof.ProfileStatus = profile.ProfileStatus; 
            Database.Profiles.Update(prof);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
