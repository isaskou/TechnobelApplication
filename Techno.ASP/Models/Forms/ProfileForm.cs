using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models.FormsModel;
using Techno.ASP.Services;

namespace Techno.ASP.Models.Forms
{
    public class ProfileForm
    {
        IServices<SectionModel, SectionForm> _sectionService;
        public ProfileForm(IServices<SectionModel, SectionForm> service)
        {
            _sectionService = service;
        }

        public ProfileForm()
        {

        }


        public int Id { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }

        [MaxLength(255, ErrorMessage = "Votre lien ne peut faire que 255 caractères")]
        [DataType(DataType.Url)]
        public string LinkedIn { get; set; }

        [MaxLength(255, ErrorMessage ="Max 255 caractères")]
        public string Hobbies { get; set; }
        public string Studies { get; set; }
        public string ProfessionalExperience { get; set; }

        public bool IsPublished { get; set; } = false;

        [Required]
        public int UserId { get; set; }

        public int? SectionId { get; set; }

        //ajouter une liste de section pour la liste déroulante
        public IEnumerable<SectionModel> LesSections
        {
            get
            {
                return _sectionService?.GetAll();
            }
        }

        public IServices<SectionModel, SectionForm> SectionService
        {
            private get { return _sectionService; }

            set
            {
                _sectionService = value;
            }
        }



    }
}
