using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.FormsModel;
using Techno.DAL;
using Techno.DAL.Entities;

namespace Techno.ASP.Services
{
    public class SkillService
    {
        private readonly DataContext _dc;

        public SkillService(DataContext dc)
        {
            _dc = dc;
        }

        public IEnumerable<SkillModel> GetAll()
        {
            IEnumerable<Skill> allSkills = _dc.Skills;

            return allSkills.Select(s => new SkillModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });
        }

        public bool Delete(int id)
        {
            Skill toDelete = _dc.Skills.FirstOrDefault(x => x.Id == id);
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

        public void Insert(SkillForm form)
        {
            Skill s = new Skill
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description
            };

            _dc.Skills.Add(s);
            _dc.SaveChanges();
        }

        public SkillForm GetById(int id)
        {
            Skill s = _dc.Skills.Find(id);
            if(s != null)
            {
                return new SkillForm
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                };
            }
            else
            {
                return null;
            }
        }

        public void Update(SkillForm form) 
        {
            Skill s = _dc.Skills.Find(form.Id);
            s.Name = form.Name;
            s.Description = form.Description;
            _dc.SaveChanges();
        }
    }
}
