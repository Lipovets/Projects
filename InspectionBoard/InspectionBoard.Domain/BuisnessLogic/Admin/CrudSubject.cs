//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using InspectionBoard.Domain.Context;
//using InspectionBoard.Domain.Entity;

//namespace InspectionBoard.Domain.BuisnessLogic.Admin
//{
//    public class CrudSubject
//    {
//        ////repo
//        //public List<Subject> DisplaySubjects()
//        //{
//        //    List<Subject> subjects;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        subjects = context.Subjects.ToList();
//        //    }
//        //    return subjects;
//        //}

//        ////repo
//        //public void Create(Subject subject)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(subject).State = EntityState.Added;
//        //        context.SaveChanges();
//        //    }
//        //}

//        //public Subject Edit(int id)
//        //{
//        //    Subject subject;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        subject = context.Subjects.Find(id);
//        //    }
//        //    return subject;
//        //}

//        ////repo
//        //public void Edit(Subject subject)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(subject).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////repo
//        //public void Delete(int id)
//        //{
//        //    Subject subject;
//        //    using(InspectionBoardContext contex = new InspectionBoardContext())
//        //    {
//        //        subject = contex.Subjects.Find(id);
//        //        contex.Entry(subject).State = EntityState.Deleted;
//        //        contex.SaveChanges();
//        //    }
//        //}

//        ////repo
//        //public HashSet<Subject> SubjectFor()
//        //{
//        //    List<Subject> subjects;
//        //    HashSet<string> has = new HashSet<string>();
//        //    HashSet<Subject> list = new HashSet<Subject>();
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        subjects = context.Subjects.ToList();
//        //    }
//        //    foreach (var i in subjects)
//        //    {
//        //        has.Add(i.Name);
//        //    }
//        //    foreach (var i in has)
//        //    {
//        //        list.Add(FindByName(i));
//        //    }
//        //    //for (int item = 0; item < subjects.Count(); item++)
//        //    //{
//        //    //    for (int index = 0; index < subjects.Count(); index++)
//        //    //        if ((subjects[item].Name == subjects[index].Name) && (item != index))
//        //    //        {
//        //    //            subjects.Remove(subjects[item]);
//        //    //        }
//        //    //}
//        //    //foreach (var item in subjects)
//        //    //{
//        //    //    has.Add(item);
//        //    //}
//        //    return list;
//        //}

//        ////repo
//        //public Subject FindByName(string name)
//        //{
//        //    Subject subject;
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        subject = context.Subjects.Where(x => x.Name == name).First();
//        //    }
//        //    return subject;
//        //}

//        //public Specialty SubjectForSpecialty(int id)
//        //{
//        //    Specialty specilty;
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        specilty = context.Specialties.Include(x => x.Subjects).Where(x => x.Id == id).First();
//        //    }
//        //    return specilty;
//        //}

//        //public List<string> GetNameFromSubject(Specialty specialty)
//        //{
//        //    List<string> nameSubject = new List<string>();
//        //    foreach (Subject item in specialty.Subjects)
//        //    {
//        //        nameSubject.Add(item.Name);
//        //    }
//        //    return nameSubject;
//        //}

//        //public void ChangeSubject(int id, int[] SelectedSubject)
//        //{
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        Specialty specialty = context.Specialties.Include(x => x.Subjects).First(x => x.Id == id);
//        //        specialty.Subjects.Clear();
//        //        context.Entry(specialty).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //        if (SelectedSubject != null)
//        //        {

//        //            foreach (int item in SelectedSubject)
//        //            {
//        //                specialty.Subjects.Add(FindById(item));
//        //            }
//        //            context.SaveChanges();

//        //        }
//        //    }
//        //}

//        ////repo
//        //public Subject FindById(int id)
//        //{
//        //    Subject subject;
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        subject = context.Subjects.Where(x => x.Id == id).First();
//        //    }
//        //    return subject;
//        //}


//    }
//}
