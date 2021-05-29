using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Techno.DAL.Entities;

namespace Techno.ASP.Models.Forms
{
    public class UserForm
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Ce champ est requis")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage ="Il semble que ce ne soit pas une adresse mail")]
        public string Email { get; set; }

        [Required]
        [MinLength(9, ErrorMessage ="Votre mot de passe doit contenir min. 9 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Votre MDP ne correspond pas")]
        public string RePassword { get; set; }

        [Required (ErrorMessage ="Ce champ est requis")]
        [MaxLength(50, ErrorMessage ="Maximum 50 caractères")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ce champ est requis")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Ce champ est requis")]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
    }
}
