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
        
        [MaxLength(50)]
        public string ImageMimeType { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [MaxLength(255)]
        public string LinkedIn { get; set; }

        [MaxLength(255)]
        public string Hobbies { get; set; }
        public string Studies { get; set; }
        public string ProfessionalExperience { get; set; }
        
        [Required]
        public bool IsPublished { get; set; }


        //public int UserId { get; set; }
        //public int? SectionId { get; set; }

        //public virtual UserModel User { get; set; }
        //public virtual SectionModel Section { get; set; }
        //public virtual IEnumerable<SkillModel> Skills { get; set; }


    }
}
