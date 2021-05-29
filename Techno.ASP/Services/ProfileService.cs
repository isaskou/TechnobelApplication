using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.DAL;
using Techno.DAL.Entities;

namespace Techno.ASP.Services
{
    public class ProfileService : IServices<ProfileModel, ProfileForm>
    {
        private readonly DataContext _dc;

        public ProfileService(DataContext dc)
        {
            _dc = dc;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfileModel> GetAll()
        {
            IEnumerable<Profile> allProfiles = _dc.Profiles;

            return allProfiles.Select(p => new ProfileModel
            {
                //Id = p.Id,
                //FullName = p.User.FirstName + " " + p.User.LastName,
                //SectionName = p.Section.Name
            });
        }

        public ProfileForm GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProfileForm form)
        {
            //1. Mapping de Form vers le model
            ProfileModel model = new ProfileModel()
            {
                Description = form.Description,
                Hobbies = form.Hobbies,
                LinkedIn = form.LinkedIn,
                ProfessionalExperience = form.ProfessionalExperience,
                IsPublished = form.IsPublished,
                SectionId = form.SectionId,
                Studies = form.Studies,
                UserId = form.UserId,
                ImageMimeType = form.ImageFile.ContentType,
                ImageFile = UploadMe(form.ImageFile)
            };

            //2. Model vers Entity
            Profile entity = new Profile()
            {
                Description = model.Description,
                Hobbies = model.Hobbies,
                LinkedIn = model.LinkedIn,
                ProfessionalExperience = model.ProfessionalExperience,
                IsPublished = model.IsPublished,
                SectionId = model.SectionId,
                Studies = model.Studies,
                UserId = model.UserId,
                ImageMimeType = model.ImageMimeType,
                ImageFile = model.ImageFile

            };
            _dc.Profiles.Add(entity);
            _dc.SaveChanges();
        }

        private byte[] UploadMe(IFormFile imageFile)
        {
            if (imageFile == null) return null;

            byte[] imageEnByte = null;
            
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                imageEnByte = memoryStream.ToArray();
            }
            return imageEnByte;

        }

        public void Update(ProfileForm form)
        {
            throw new NotImplementedException();
        }
    }
}
