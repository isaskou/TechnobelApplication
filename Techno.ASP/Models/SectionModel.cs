using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models
{
    public class SectionModel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }


        //public virtual IEnumerable<ProfileModel> Profiles { get; set; }


    }
}
