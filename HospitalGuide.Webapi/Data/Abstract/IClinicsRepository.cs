using HospitalGuide.Webapi.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Abstract
{
    public interface IClinicsRepository
    {
        IEnumerable<Clinics> GetClinics();
        IEnumerable<Hospitals> Gethospital(string city);
        HospitalClinics GetHospitalClinics(int clinic, int hospital);
        IEnumerable GetOneHospital(int hospital);
        IEnumerable GetDoctors();
        IEnumerable<Hospitals> SearchHospital(string hospital, string city);

        IEnumerable GetComments(int hospital);
        IEnumerable<Comments> GetallComments();
        IEnumerable<Hospitals> GetAllhospital();
        IEnumerable GetOneHospitalAndClinicDoctors(int hosclinicid);

        void addClinic(Clinics add);

        void updateClinic(Clinics update);

        void deleteClinic(int delete);


        void addHospital(Hospitals add);

        void updateHospital(Hospitals update);

        void deleteHospital(int delete);


        void addHospitalClinic(HospitalClinics add);

        void updateHospitalClinic(HospitalClinics update);

        void deleteHospitalClinic(int delete);



        void addDoctor(Doctors add);

        void updateDoctor(Doctors update);

        void deleteDoctor(int delete);


        void addComment(Comments add);

        void updateComment(Comments update);

        void deleteComment(int delete);
        Doctors GetDoctorid(int id);
        IEnumerable GetDoctor(int id);
        Hospitals Getthospital(int id);
        Clinics GettClinic(int id);
        HospitalClinics GettHosCil(int id);
      


    }
}
