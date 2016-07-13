using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoard.Domain.Entity;
using System.Data.Entity;
using InspectionBoard.Domain.Context;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class SubjectRepository : IRepository<Subject>
    {
        private InspectionBoardContext context;

        public SubjectRepository()
        {
            this.context = new InspectionBoardContext();
        }

        public IEnumerable<Subject> GetObjectList()
        {
            return context.Subjects.ToList();
        }

        public void Create(Subject subject)
        {
            context.Entry(subject).State = EntityState.Added;
            Save();
        }

        public void Edit(Subject subject)
        {
            context.Entry(subject).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Subject subject = context.Subjects.Find(id);
            if (subject != null)
            {
                context.Entry(subject).State = EntityState.Deleted;
                Save();
            }
        }

        public HashSet<Subject> SubjectFor()
        {

            HashSet<string> has = new HashSet<string>();
            HashSet<Subject> list = new HashSet<Subject>();

            List<Subject> subjects = context.Subjects.ToList();

            foreach (var i in subjects)
            {
                has.Add(i.Name);
            }
            foreach (var i in has)
            {
                list.Add(FindByName(i));
            }

            return list;
        }

        public Subject FindByName(string name)
        {
            return context.Subjects.Where(x => x.Name == name).First();
        }

        public Specialty SubjectForSpecialty(int id)
        {
            return context.Specialties.Include(x => x.Subjects).Where(x => x.Id == id).First();
        }

        public List<string> GetNameFromSubject(Specialty specialty)
        {
            List<string> nameSubject = new List<string>();
            foreach (Subject item in specialty.Subjects)
            {
                nameSubject.Add(item.Name);
            }
            return nameSubject;
        }

        public void ChangeSubject(int id, int[] SelectedSubject)
        {
            Specialty specialty = context.Specialties.Include(x => x.Subjects).First(x => x.Id == id);
            specialty.Subjects.Clear();
            context.Entry(specialty).State = EntityState.Modified;
            Save();
            if (SelectedSubject != null)
            {
                foreach (int item in SelectedSubject)
                {
                    specialty.Subjects.Add(FindById(item));
                }
                Save(); 
            } 
        } 

        public Subject FindById(int id)
        {
            return context.Subjects.Where(x => x.Id == id).First();
        } 

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
