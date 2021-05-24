using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        public byte[] Password { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        
        //public string Role { get; set; }

        public virtual ProfileModel Profile { get; set; }

    }
}
