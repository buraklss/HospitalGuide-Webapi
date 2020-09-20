using HospitalGuide.Webapi.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Abstract
{
   public interface IAppointmentRepository
    {

        IEnumerable<AppointmentDays> GetDays(int doctor, bool status);
        IEnumerable<AppointmentHours> GetHours(int day, bool status);
        IEnumerable<AppointmentDays> GetAllDays(int doctor);
        IEnumerable<AppointmentHours> GetAllHours(int day);
        IEnumerable<AppointmentDays> GetAllDaystrue();
        IEnumerable<AppointmentHours> GetAllHourstrue();
        IEnumerable GetRandevu(int user);
        IEnumerable AllRandevu();
        IEnumerable<AppointmentDays> AllDays();
        IEnumerable<AppointmentDays> AllDaystrue();
        IEnumerable<AppointmentHours> AllHours();
        AppointmentHours getoneHour(int id);
        AppointmentDays getOneDay(int id);

        void addOTOAppHour(AppointmentHours add);

        void addAppDay(AppointmentDays add);

        void updateAppDay(AppointmentDays update);

        void deleteAppDay(int delete);


        void addAppHour(AppointmentHours add);

        void updateAppHour(AppointmentHours update);

        void deleteAppHour(int delete);


        void addRandevu(Randevular add);

        void updateRandevu(Randevular update);

        void deleteRandevu(int delete);


    }
}
