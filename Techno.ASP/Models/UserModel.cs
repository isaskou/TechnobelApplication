using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Techno.DAL.Entities;

namespace Techno.ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] PasswordOut
        {
            get
            {
                return HashMe(PasswordIn);
            }
        }


        public string PasswordIn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Role Role { get; set; }


        private byte[] HashMe(string passwordIn)
        {
            //crypto ===> namespace
            //Sha 512
            //byte[]

            byte[] data = Encoding.UTF8.GetBytes(passwordIn);
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            return result;

        }


    }


}
