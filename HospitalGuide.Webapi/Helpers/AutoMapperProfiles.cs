using AutoMapper;
using HospitalGuide.Webapi.Detos;
using HospitalGuide.Webapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctorDTO = HospitalGuide.Webapi.Detos.doctorDTO;

namespace HospitalGuide.Webapi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //kaynak   , hedef
            CreateMap<UserInfo, userRegisterDTO>();
            CreateMap<userRegisterDTO, UserInfo>();

           
            CreateMap<Hospitals, hospitalDTO>();
            CreateMap<hospitalDTO, Hospitals>();
            CreateMap<HospitalClinics, hospitalclinicDTO>();
            CreateMap<Clinics, clinicDTO>();
            CreateMap<clinicDTO, Clinics>();
            CreateMap<doctorDTO, Doctors>();
            CreateMap<Doctors, doctorDTO>();

            



        }
    }
 
}