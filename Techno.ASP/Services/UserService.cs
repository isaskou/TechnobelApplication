using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.DAL;
using Techno.DAL.Entities;

namespace Techno.ASP.Services
{
    public class UserService : IServices<UserModel, UserForm>
    {
        private readonly DataContext _dc;

        public UserService(DataContext dc)
        {
            _dc = dc;
        }

        public IEnumerable<UserModel> GetAll()
        {
            IEnumerable<User> allUsers = _dc.Users;

            return allUsers.Select(u => new UserModel
            {
                Id = u.Id,
                Email = u.Email,
                LastName = u.LastName,
                FirstName = u.FirstName,
                BirthDate = u.BirthDate,
                Role = u.Role,

            });

        }

        public void Insert(UserForm form)
        {
            UserModel model = new UserModel
            {
                Email = form.Email,
                PasswordIn = form.Password,
                FirstName = form.FirstName,
                LastName = form.LastName,
                BirthDate = form.BirthDate,
                Role = form.Role
            };

            User entity = new User()
            {
                Email = model.Email,
                Password = model.PasswordOut,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Role = model.Role
            };

            _dc.Users.Add(entity);
            _dc.SaveChanges();

            //permet de mettre l'id calculé dans la db dans le form
            form.Id = entity.Id;
        }

        public UserForm GetById(int id)
        {
            User u = _dc.Users.Find(id);
            if (u != null)
            {
                return new UserForm
                {
                    Email = u.Email,
                    //Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    BirthDate = u.BirthDate,
                    Role = (Role)u.Role
                };
            }
            else
            {
                return null;
            }
        }

        public void Update(UserForm form)
        {
            User u = _dc.Users.Find(form.Id);
            u.Email = form.Email;
            //u.Password = form.Password;
            u.FirstName = form.FirstName;
            u.LastName = form.LastName;
            u.BirthDate = form.BirthDate;
            u.Role = (DAL.Entities.Role)form.Role;

            _dc.SaveChanges();
        }

        public bool Delete(int id)
        {
            User toDelete = _dc.Users.Find(id);

            if (toDelete == null)
            {
                return false;
            }
            else
            {
                _dc.Remove(toDelete);
                _dc.SaveChanges();
                return true;
            }
        }
    }
}
