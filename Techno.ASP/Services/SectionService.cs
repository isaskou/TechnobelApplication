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
    public class SectionService : IServices<SectionModel, SectionForm>
    {
        private readonly DataContext _dc;

        public SectionService(DataContext dc)
        {
            _dc = dc;
        }

        public IEnumerable<SectionModel> GetAll()
        {
            IEnumerable<Section> allSections = _dc.Sections;

            return allSections.Select(s => new SectionModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });
        }

        public void Insert(SectionForm form)
        {
            Section s = new Section
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description
            };

            _dc.Sections.Add(s);
            _dc.SaveChanges();
        }

        public SectionForm GetById(int id)
        {
            Section s = _dc.Sections.Find(id);

            if (s != null)
            {
                return new SectionForm
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

        public void Update(SectionForm form)
        {
            Section s = _dc.Sections.Find(form.Id);
            s.Name = form.Name;
            s.Description = form.Description;
            _dc.SaveChanges();
        }

        public bool Delete(int id)
        {
            Section toDelete = _dc.Sections.Find(id);

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
