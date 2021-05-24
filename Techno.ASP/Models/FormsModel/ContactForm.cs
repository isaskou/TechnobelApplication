using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models.FormsModel
{
    public class ContactForm 
    {
        [Required(ErrorMessage ="Ce champ est requis")]
        [MaxLength(255, ErrorMessage ="Le champ doit faire maximum 255 caractères")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Ce champ est requis")]
        [MinLength(2, ErrorMessage ="Vous avez certainement plus de choses à dire... ")]
        [MaxLength(1000, ErrorMessage ="Vous bavardez trop... Le champ doit faire maximum 1000 caratères")]
        public string Message { get; set; }
    }
}
