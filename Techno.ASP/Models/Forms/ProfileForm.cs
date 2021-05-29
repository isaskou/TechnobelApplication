using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models.Forms
{
    public class ProfileForm
    {
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




        //public virtual UserModel User { get; set; }
        //public virtual SectionModel Section { get; set; }
        //public virtual IEnumerable<SkillModel> Skills { get; set; }


    }
}
