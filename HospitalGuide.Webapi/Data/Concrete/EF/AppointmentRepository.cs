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
    public class AppointmentRepository : IAppointmentRepository
    {
        private DataContext Context;

        public AppointmentRepository(DataContext _context)
        {
             Context = _context;
        }

        public IEnumerable AllRandevu()
        {
            var result = from Randevular in Context.Randevular
                         join Hour in Context.AppointmentHours on Randevular.HourId equals Hour.Id
                         join Day in Context.AppointmentDays on Hour.DayId equals Day.Id
                         join Doctors in Context.Doctors on Day.DoctorId equals Doctors.Id
                         join HospitalClinics in Context.HospitalClinics on Doctors.HospitalClinicId equals HospitalClinics.Id
                         join Hospitals in Context.Hospitals on HospitalClinics.HospitalId equals Hospitals.Id
                         join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id

                         select new
                         {
                             id = Randevular.Id,
                             randevuId=Randevular.Id,
                             user=Randevular.UserId,
                             hourId=Randevular.HourId,
                             hour=Hour.Time,
                             hourStatus=Hour.Status,
                             dayId=Hour.DayId,
                             day=Day.Date,
                             dayStatus=Day.Status,
                             Doctor=Day.DoctorId,

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

        public IEnumerable<AppointmentDays> AllDays()
        {
            return Context.AppointmentDays.Include(a =>a.Doctor);
        }

        public IEnumerable<AppointmentDays> AllDaystrue()
        {
            return Context.AppointmentDays.Include(a => a.Doctor).Where(a=>a.Status ==true);
        }

        public IEnumerable<AppointmentHours> AllHours()
        {
            return Context.AppointmentHours.Include(a => a.Day).ThenInclude(a=>a.Doctor);
        }

        public AppointmentHours getoneHour(int id)
        {
            return Context.AppointmentHours.Find(id);
        }

        public AppointmentDays getOneDay(int id)
        {
            return Context.AppointmentDays.Find(id);
        }

        public IEnumerable<AppointmentHours> GetAllHourstrue()
        {

            var AppHouts = Context.AppointmentHours.Where(a => a.Status == true).OrderBy(a => a.Time);
            return AppHouts;
        }

        public IEnumerable GetRandevu(int user)
        {
            var result = from Randevular in Context.Randevular
                         join Hour in Context.AppointmentHours on Randevular.HourId equals Hour.Id
                         join Day in Context.AppointmentDays on Hour.DayId equals Day.Id
                         join Doctors in Context.Doctors on Day.DoctorId equals Doctors.Id
                         join HospitalClinics in Context.HospitalClinics on Doctors.HospitalClinicId equals HospitalClinics.Id
                         join Hospitals in Context.Hospitals on HospitalClinics.HospitalId equals Hospitals.Id
                         join Clinics in Context.Clinics on HospitalClinics.ClinicId equals Clinics.Id
                         where Randevular.UserId==user
                         select new
                         {
                             id = Randevular.Id,
                             randevuId = Randevular.Id,
                             user = Randevular.UserId,
                             hourId = Randevular.HourId,
                             hour = Hour.Time,
                             hourStatus = Hour.Status,
                             dayId = Hour.DayId,
                             day = Day.Date,
                             dayStatus = Day.Status,
                             Doctor = Day.DoctorId,

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

        public void addAppDay(AppointmentDays add)
        {

            var hours = Context.AppointmentDays.Where(a => a.DoctorId == add.DoctorId);
            foreach (var d in hours)
            {
                if (Equals(d.Date, add.Date))
                {
                    return;

                }


            }

            add.Status = true;
            Context.AppointmentDays.Add(add);
            Context.SaveChanges();
        }

        public void addAppHour(AppointmentHours add)
        {
            var hours = Context.AppointmentHours.Where(a=>a.DayId == add.DayId);
            foreach (var d in hours)
            {
                if (Equals(d.Time, add.Time))
                {
                    return;

                }

        
            }


            add.Status = true;
            Context.AppointmentHours.Add(add);
            Context.SaveChanges();

        
        }
        public void addOTOAppHour(AppointmentHours add)
        {
            var hours = Context.AppointmentHours.Where(a => a.DayId == add.DayId);
            foreach (var d in hours)
            {
                if (Equals(d.Time, add.Time))
                {
                    return;

                }


            }

            string[] date =
            {
                "11.11.2018 09:00:00",
                "11.11.2018 09:30:00",
                "11.11.2018 10:00:00",
                "11.11.2018 10:30:00"   ,
                "11.11.2018 11:00:00"  ,
                "11.11.2018 11:30:00"   ,
                "11.11.2018 13:00:00"  ,
                "11.11.2018 13:30:00"     ,
                "11.11.2018 14:00:00"   ,
                "11.11.2018 14:30:00"  ,
                "11.11.2018 15:00:00"   ,
                "11.11.2018 15:30:00" ,
                "11.11.2018 16:00:00"   ,
                "11.11.2018 16:30:00" ,
                "11.11.2018 17:00:00"
            };

            for (int i = 0; i < date.Length; i++)
            {
                add.Time = Convert.ToDateTime(date[i]);
                add.Status = true;
                add.Id = 0;
                Context.AppointmentHours.Add(add);

                System.Threading.Thread.Sleep(75);
                Context.SaveChanges();
            }
          
          


          


        }

        public void addRandevu(Randevular add)
        {
            var hour = Context.AppointmentHours.Find(add.HourId);
            if(hour.Status == true) { 
            Context.Randevular.Add(add);
           
            hour.Status = false;
            Context.AppointmentHours.Update(hour);
                Context.SaveChanges();
            }
            
        }

        public void deleteAppDay(int delete)
        {
            var giris = Context.AppointmentDays.Find(delete);
            Context.AppointmentDays.Remove(giris);
            Context.SaveChanges();
        }

        public void deleteAppHour(int delete)
        {
            var giris = Context.AppointmentHours.Find(delete);
            Context.AppointmentHours.Remove(giris);
            Context.SaveChanges();
        }

        public void deleteRandevu(int delete)
        {   
            var giris = Context.Randevular.Find(delete);
            var hourid= giris.HourId;
            var hour = Context.AppointmentHours.Find(hourid);
            hour.Status = true;
            Context.Randevular.Remove(giris);
            Context.SaveChanges();
        }


        public IEnumerable<AppointmentHours> GetAllHours(int day)
        {
            var AppHouts = Context.AppointmentHours.Include(a => a.Day).ThenInclude(a=>a.Doctor).Where(a => a.DayId == day).OrderBy(a => a.Time);
            return AppHouts;
        }

        public IEnumerable<AppointmentDays> GetAllDaystrue()
        {
            var AppHouts = Context.AppointmentDays.Include(a => a.Doctor).Where(a => a.Status == true).OrderBy(a => a.Date);
            return AppHouts;
        }

        public IEnumerable<AppointmentDays> GetAllDays(int doctor)
        {
            var AppDays = Context.AppointmentDays.Where(a => a.DoctorId == doctor).OrderBy(a => a.Date);
            return AppDays;
        }


        public IEnumerable<AppointmentDays> GetDays(int doctor, bool status)
        {
            var AppDays = Context.AppointmentDays.Where(a => a.DoctorId == doctor).Where(b => b.Status == status).OrderBy(a => a.Date).Include(d=>d.Doctor);
            return AppDays;
        }

        public IEnumerable<AppointmentHours> GetHours(int day, bool status)
        {
            var AppHouts = Context.AppointmentHours.Include(a=> a.Day).Where(a => a.DayId == day).Where(b => b.Status == status).OrderBy(a => a.Time);
            return AppHouts;
        }

       

        public void updateAppDay(AppointmentDays update)
        {
            Context.AppointmentDays.Update(update);
            Context.SaveChanges();
        }

        public void updateAppHour(AppointmentHours update)
        {
            Context.AppointmentHours.Update(update);
            Context.SaveChanges();
        }

        public void updateRandevu(Randevular update)
        {
            Context.Randevular.Update(update);
            Context.SaveChanges();
        }
    }
}
