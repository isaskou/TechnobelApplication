using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models.FormsModel
{
    public class SectionForm
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Ce champ est requis")]
        [MaxLength(50, ErrorMessage ="Le champ doit faire maximum 50 caractères")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Ce champ est requis")]
        public string Description { get; set; }
    }
}
