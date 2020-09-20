using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Concrete.EF
{
    public class ClinicRepository : IClinicsRepository
    {
        private DataContext Context;

        public IEnumerable<Hospitals> SearchHospital(string hospital, string city)
        {
            var result = Context.Hospitals.Where(a => a.Name.Contains(hospital) && a.City == city).OrderBy(a => a.Name);
            return result;
        }

        public ClinicRepository(DataContext _context)
        {
            Context = _context;
        }

        public IEnumerable<Comments> GetallComments()
        {
            return Context.Comments;
        }

        public IEnumerable<Hospitals> GetAllhospital()
        {
            return Context.Hospitals;

        }

        public void addClinic(Clinics add)
        {
            Context.Clinics.Add(add);
            Context.SaveChanges();
        }

        public void addComment(Comments add)
        {
            Context.Comments.Add(add);
            Context.SaveChanges();
        }

        public void addDoctor(Doctors add)
        {
            Context.Doctors.Add(add);
            Context.SaveChanges();
        }

        public void addHospital(Hospitals add)
        {
            Context.Hospitals.Add(add);
            Context.SaveChanges();
        }

        public void addHospitalClinic(HospitalClinics add)
        {
            Context.HospitalClinics.Add(add);
            Context.SaveChanges();
        }

        public void deleteClinic(int delete)
        {
            var giris = Context.Clinics.Find(delete);
            Context.Clinics.Remove(giris);
            Context.SaveChanges();
        }

        public void deleteComment(int delete)
        {
            var giris = Context.Comments.Find(delete);
            Context.Comments.Remove(giris);
            Context.SaveChanges();
        }

        public Doctors GetDoctorid(int id)
        {
            return Context.Doctors.Find(id);
        }

        public void deleteDoctor(int delete)
        {
            var giris = Context.Doctors.Find(delete);
            Context.Doctors.Remove(giris);
            Context.SaveChanges();
        }

        public void deleteHospital(int delete)
        {
            var giris = Context.Hospitals.Find(delete);
            Context.Hospitals.Remove(giris);
            Context.SaveChanges();
        }

        public void deleteHospitalClinic(int delete)
        {
            var giris = Context.HospitalClinics.Find(delete);
            Context.HospitalClinics.Remove(giris);
            Context.SaveChanges();
        }

        public IEnumerable<Clinics> GetClinics()
        {
            
            return Context.Clinics.ToList();
        }

        public IEnumerable GetDoctor(int id)
        {
            var result = from Doctors in Context.Doctors
                join HospitalClinics in Context.HospitalClinics on Doctors.HospitalClinicId equals HospitalClinics.Id
                join Hospitals in Context.Hospitals on HospitalClinics.HospitalId equals Hospitals.Id
                join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id
                         where Doctors.Id == id
                select new
                {
                    id = Doctors.Id,
                    title = Doctors.Title,
                    name = Doctors.Name,
                    surname = Doctors.Surname,
                    gender = Doctors.Gender,
                    hospitalClinic = Doctors.HospitalClinicId,
                    clinicId = Clinics.Id,
                    clinic = Clinics.Name,
                    hospitalId = Hospitals.Id,
                    hospitalName = Hospitals.Name
                };
            return result;
        }

        public Hospitals Getthospital(int id)
        {
            return Context.Hospitals.Find(id);

        }

        public Clinics GettClinic(int id)
        {
            return Context.Clinics.Find(id);

        }

        public HospitalClinics GettHosCil(int id)
        {
            return Context.HospitalClinics.Find(id);

        }

        public IEnumerable GetComments(int hospital)
        {
            var Commentlist = Context.Comments.Include(a=>a.User).Where(a => a.HospitalId == hospital).OrderBy(a => a.CommentTime);
            var result = from Comments in Context.Comments
                join UserInfo in Context.UserInfo on Comments.UserId equals UserInfo.Id
                where Comments.HospitalId == hospital
                
                select new
                {
                   id = Comments.Id,
                   comment = Comments.Comment,
                    commettime =Comments.CommentTime,
                    hospitalid = Comments.HospitalId,
                    userid = Comments.UserId,
                    username= UserInfo.Name,
                    gander = UserInfo.Gender,
                    surname = UserInfo.Surname,
                    mail =UserInfo.Mail

                };


            return result;
        }

        public IEnumerable GetDoctors()
        {

            var result = from Doctors in Context.Doctors
                         join HospitalClinics in Context.HospitalClinics on Doctors.HospitalClinicId equals HospitalClinics.Id
                         join Hospitals in Context.Hospitals on HospitalClinics.HospitalId equals Hospitals.Id
                         join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id
                         select new
                         {
                             id = Doctors.Id,
                             title = Doctors.Title,
                             name = Doctors.Name,
                             surname = Doctors.Surname,
                             gender = Doctors.Gender,
                             hospitalClinic = Doctors.HospitalClinicId,
                             clinicId = Clinics.Id,
                             clinic = Clinics.Name,
                             hospitalId = Hospitals.Id,
                             hospitalName = Hospitals.Name
                         };
            return result;
        }

        public IEnumerable<Hospitals> Gethospital(string city)
        {
            var Hospitallist = Context.Hospitals.Where(a => a.City == city).OrderBy(a => a.Name);
            return Hospitallist;
        }

        public HospitalClinics GetHospitalClinics(int clinic, int hospital)
        {
            var Hospitalclinic = Context.HospitalClinics.SingleOrDefault(a => a.ClinicId == clinic && a.HospitalId == hospital);

            return Hospitalclinic;
        }

        public IEnumerable GetOneHospital(int hospital)
        {
           // var Hospitalcliniclist = Context.Hospitals.Include(a=>a.HospitalClinics).ThenInclude(a=>a.Clinic).Where(b => b.Id == hospital).OrderBy(a => a.Name);
            var listt = from Hospitals in Context.Hospitals
                join HospitalClinics in Context.HospitalClinics on Hospitals.Id equals HospitalClinics.HospitalId
                join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id
                where Hospitals.Id == hospital
                select new
                {
                    id = Clinics.Id,
                    name =Clinics.Name,
                    hosname = Hospitals.Name
                };

            return listt;
        }



        public IEnumerable GetOneHospitalAndClinicDoctors(int hosclinicid)
        {
          
            var result = from Doctors in Context.Doctors
                         join HospitalClinics in Context.HospitalClinics on Doctors.HospitalClinicId equals HospitalClinics.Id
                         join Hospitals in Context.Hospitals on HospitalClinics.HospitalId equals Hospitals.Id
                         join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id
                         where HospitalClinics.Id==hosclinicid
                         select new
                         {
                             id = Doctors.Id,
                             title = Doctors.Title,
                             name = Doctors.Name,
                             surname = Doctors.Surname,
                             gender = Doctors.Gender,
                             hospitalClinic = Doctors.HospitalClinicId,
                             clinicId = Clinics.Id,
                             clinic = Clinics.Name,
                             hospitalId = Hospitals.Id,
                             hospitalName = Hospitals.Name
                         };
            return result;
        }
       

        public void updateClinic(Clinics update)
        {
            Context.Clinics.Update(update);
            Context.SaveChanges();
        }

        public void updateComment(Comments update)
        {
            Context.Comments.Update(update);
            Context.SaveChanges();
        }

        public void updateDoctor(Doctors update)
        {
            Context.Doctors.Update(update);
            Context.SaveChanges();
        }

        public void updateHospital(Hospitals update)
        {
            Context.Hospitals.Update(update);
            Context.SaveChanges();
        }

        public void updateHospitalClinic(HospitalClinics update)
        {
            Context.HospitalClinics.Update(update);
            Context.SaveChanges();
        }
    }
}
