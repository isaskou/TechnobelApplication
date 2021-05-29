using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models
{
    public class ProfileModel 
    {
        public int Id { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        public string Description { get; set; }
        public string LinkedIn { get; set; }
        public string Hobbies { get; set; }
        public string Studies { get; set; }
        public string ProfessionalExperience { get; set; }
        public bool IsPublished { get; set; }

        public int UserId { get; set; }
        public int? SectionId { get; set; }


    }
}
