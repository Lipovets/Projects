using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Data.Entity;
using BLL.DTO;
using sashkogram.Models;
using System.IO;
using BLL.Services;

namespace sashkogram.Controllers
{
    public class HomeController : Controller
    {
        private IService photoService;

        public HomeController()
        {

        }

        public HomeController(IService serv)
        {
            this.photoService = serv;
        }

        public ActionResult Index(int profileId = 1)
        {
            Mapper.CreateMap<ProfileDTO, ProfileViewModel>()
                .ForMember(a=>a.ProfilePhotos, b=>b.Ignore())
                .ForMember(a => a.Avatars, b => b.Ignore()); 
            ProfileViewModel profile = Mapper.Map<ProfileDTO, ProfileViewModel>(photoService.GetProfile(profileId));
            foreach (PhotoDTO item in photoService.GetProfile(profileId).ProfilePhotos)
            { 
                profile.ProfilePhotos.Add(new PhotoViewModel() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileViewModelId = item.ProfileDTOId });
            }

            foreach (PhotoDTO item in photoService.GetProfile(profileId).Avatars)
            {
                profile.Avatars.Add(new PhotoViewModel() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileViewModelId = item.ProfileDTOId });
            }
            return View(profile);
        }

        [HttpGet]
        public ActionResult AddPhoto(int id)
        {
            ViewBag.ProfileId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddPhoto(PhotoViewModel photo, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binnaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binnaryReader.ReadBytes(uploadImage.ContentLength);
                }
                photo.Image = imageData;
                Mapper.CreateMap<PhotoViewModel, PhotoDTO>()
                    .ForMember("ProfileDTOId", opt => opt.MapFrom(c => c.ProfileViewModelId));
                PhotoDTO newPhoto = Mapper.Map<PhotoViewModel, PhotoDTO>(photo);
                photoService.AddPhotoToProfile(newPhoto, (int)newPhoto.ProfileDTOId);
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        [HttpGet]
        public ActionResult ChangeAvatar(int id)
        {
            Mapper.CreateMap<ProfileDTO, ProfileViewModel>() 
                .ForMember(a => a.ProfilePhotos, b => b.Ignore()) 
                .ForMember(a => a.Avatars, b => b.Ignore());
            ProfileViewModel profile = Mapper.Map<ProfileDTO, ProfileViewModel>(photoService.GetProfile(id));
            foreach (PhotoDTO item in photoService.GetProfile(id).Avatars)
            {
                profile.Avatars.Add(new PhotoViewModel() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileViewModelId = item.ProfileDTOId });
            }
            return View(profile);
        }

        [HttpPost]
        public ActionResult ChangeAvatar(PhotoViewModel photo)
        {
            return RedirectToAction("Index");
        }   

        [HttpGet]
        public ActionResult AddAvatar(int id)
        {
            ViewBag.ProfileId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddAvatar(PhotoViewModel photo, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binnaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binnaryReader.ReadBytes(uploadImage.ContentLength);
                }
                photo.Image = imageData;
                Mapper.CreateMap<PhotoViewModel, PhotoDTO>()
                    .ForMember("ProfileDTOId", opt => opt.MapFrom(c => c.ProfileViewModelId));
                PhotoDTO newPhoto = Mapper.Map<PhotoViewModel, PhotoDTO>(photo);
                photoService.AddAvatarToProfile(newPhoto, (int)newPhoto.ProfileDTOId);
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        public ActionResult ChangeStatus(ProfileViewModel newProfile)
        { 
            Mapper.CreateMap<ProfileViewModel, ProfileDTO>();
            ProfileDTO p = Mapper.Map<ProfileViewModel, ProfileDTO>(newProfile);
            photoService.ChangeProfileStatus(p);
            Mapper.CreateMap<ProfileDTO, ProfileViewModel>()
                .ForMember(a => a.ProfilePhotos, b => b.Ignore())
                .ForMember(a => a.Avatars, b => b.Ignore());
            ProfileViewModel profile = Mapper.Map<ProfileDTO, ProfileViewModel>(photoService.GetProfile(p.Id));
            return PartialView(profile);
        }

        //public ActionResult GetPhotoOnProfile(int id, int photo)
        //{
        //    Mapper.CreateMap<ProfileDTO, ProfileViewModel>()
        //        .ForMember(a => a.ProfilePhotos, b => b.Ignore())
        //        .ForMember(a => a.Avatars, b => b.Ignore());
        //    ProfileViewModel profile = Mapper.Map<ProfileDTO, ProfileViewModel>(photoService.GetProfile(id));
        //    foreach (PhotoDTO item in photoService.GetProfile(id).ProfilePhotos)
        //    {
        //        profile.ProfilePhotos.Add(new PhotoViewModel() { Id = item.Id, Caption = item.Caption, Image = item.Image, ProfileViewModelId = item.ProfileDTOId });
        //    }
        //    PhotoViewModel p = profile.ProfilePhotos.ToList()[photo];
        //    return PartialView(p);
        //}


        protected override void Dispose(bool disposing)
        {
            photoService.Dispose();
            base.Dispose(disposing);
        }
    }
}