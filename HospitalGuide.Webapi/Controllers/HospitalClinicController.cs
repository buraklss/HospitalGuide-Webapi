using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Data.Concrete.EF;
using HospitalGuide.Webapi.Detos;
using HospitalGuide.Webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalGuide.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clinics")]
    public class HospitalClinicController : Controller
    {
        private IClinicsRepository _ClinicRep;
        private IMapper _mapper;
        private IHospitalRateRepository _HospitalRate;
        public HospitalClinicController(IClinicsRepository clinicrep, IMapper mapper,IHospitalRateRepository hospitalrate)
        {
            _ClinicRep=clinicrep;
            _mapper = mapper;
            _HospitalRate = hospitalrate;
            
        }
        [HttpGet("searchhospital")]
        public IActionResult Searchhospital(string Name, string City)
        {
            var result = _ClinicRep.SearchHospital(Name, City);
            return Ok(result);
        }
        [HttpGet("Clinics")]
        public IActionResult GetClinics()
        {
            var model2 = _ClinicRep.GetClinics();
            var model = _mapper.Map<List<clinicDTO>>(model2);
            return Ok(model);
        }
        [HttpGet("GetAllHospitals")]
        public IActionResult GetAllHospitals()
        {
            var hospital = _ClinicRep.GetAllhospital();
            var hos = _mapper.Map<List<hospitalDTO>>(hospital);
            return Ok(hos);
        }

        [HttpGet("GetCityInHospitals")]
        public IActionResult GetHospitals(string city)
        {
            var hospital = _ClinicRep.Gethospital(city);
            var hos = _mapper.Map<List<hospitalDTO>>(hospital);
            return Ok(hos);
        }

        [HttpGet("GetOneHospitalsClinics")]
        public IActionResult GetOneHospitals(int hospital)
        {
            var onehospital = _ClinicRep.GetOneHospital(hospital);
           
            return Ok(onehospital);
        }
        
        [HttpGet("HospitalClinic")]
        public IActionResult GetHospitalClinic(int clinic,int hospital)
        {
            var hospitalclinic = _ClinicRep.GetHospitalClinics(clinic,hospital);
            return Ok(hospitalclinic);
        }

        [HttpGet("AllDoctors")]
        public IActionResult GetDoctor()
        {
            var Doctor = _ClinicRep.GetDoctors();
          
            return Ok(Doctor);
        }
        [HttpGet("GetOneHosAndOneClinicInDoctors")]
        public IActionResult GetOneHCinDoctors(int hosclinicid)
        {
            var Doctors = _ClinicRep.GetOneHospitalAndClinicDoctors(hosclinicid);
           return Ok(Doctors);
        }
        [HttpGet("Comment")]
        public IActionResult GetComment(int hospital)
        {
            var Comment = _ClinicRep.GetComments(hospital);
            return Ok(Comment);
        }

        [HttpGet("AllComment")]
        public IActionResult GetallComment()
        {
            var Comment = _ClinicRep.GetallComments();
            return Ok(Comment);
        }
        [HttpGet("Rate")]
        public IActionResult GetRate(int hospital)
        {
            var Rate = _HospitalRate.getrate(hospital);
            return Ok(Rate);
        }
        [HttpGet("RateValue")]
        public IActionResult GetRate1(int hospital)
        {
            var Rate = _HospitalRate.getratVALUE(hospital);
            return Ok(Rate);
        }

        [HttpPost("addclinic")]
        public IActionResult AddClinic([FromBody]clinicDTO add)
        {
            var clinic = _mapper.Map<Clinics>(add);
            _ClinicRep.addClinic(clinic);
            return Ok(add);
        }
        [HttpPut("updateclinic")]
        public IActionResult UpdateClinic([FromBody]clinicDTO update)
        {
            var clinic = _mapper.Map<Clinics>(update);
            _ClinicRep.updateClinic(clinic);
            return Ok(update);
        }
        [HttpDelete("deleteclinic")]
        public IActionResult DeleteClinic(int id)
        {
            _ClinicRep.deleteClinic(id);
            return Ok();
        }


        [HttpPost("addhospital")]
        public IActionResult AddHospital([FromBody]hospitalDTO add)
        {
            var hospital = _mapper.Map<Hospitals>(add);
            _ClinicRep.addHospital(hospital);
            return Ok(add);
        }
        [HttpPut("updatehospital")]
        public IActionResult UpdateHospital([FromBody]hospitalDTO update)
        {
            var hospital = _mapper.Map<Hospitals>(update);
            _ClinicRep.updateHospital(hospital);
            return Ok(update);
        }
        [HttpDelete("deletehospital")]
        public IActionResult DeleteHospital(int id)
        {
            _ClinicRep.deleteHospital(id);
            return Ok();
        }


        [HttpPost("adddoctor")]
        public IActionResult AddDoctor([FromBody]doctorDTO add)
        {
            var newdoctor = _mapper.Map<Doctors>(add);
            _ClinicRep.addDoctor(newdoctor);
            return Ok(add);
        }
        [HttpPut("updatedoctor")]
        public IActionResult UpdateDoctor([FromBody]doctorDTO update)
        {
            var updactor = _mapper.Map<Doctors>(update);
            _ClinicRep.updateDoctor(updactor);
            return Ok(update);
        }
        [HttpDelete("deletedoctor")]
        public IActionResult DeleteDoctor(int id)
        {
            _ClinicRep.deleteDoctor(id);
            return Ok();
        }

        [HttpPost("addcomment")]
        public IActionResult AddComment([FromBody]Comments add)
        {
            _ClinicRep.addComment(add);
            return Ok(add);
        }
        [HttpPost("addrate")]
        public IActionResult AddRate(int hos,int rate,string user)
        {
            _HospitalRate.addrate(hos,rate,user);
            return Ok();
        }
        [HttpPut("updatecomment")]
        public IActionResult UpdateComment([FromBody]Comments update)
        {
            _ClinicRep.updateComment(update);
            return Ok(update);
        }
        [HttpDelete("deletecomment")]
        public IActionResult DeleteComment(int id)
        {
            _ClinicRep.deleteComment(id);
            return Ok();
        }

        //----------------hoscilinic
        [HttpPost("addHospitalClinicse")]
        public IActionResult AddHospitalClinics([FromBody]HospitalClinics add)
        {
            _ClinicRep.addHospitalClinic(add);
            return Ok(add);
        }
        [HttpPut("updateHospitalClinics")]
        public IActionResult UpdateHospitalClinics([FromBody]HospitalClinics update)
        {
            _ClinicRep.updateHospitalClinic(update);
            return Ok(update);
        }
        [HttpDelete("deleteHospitalClinics")]
        public IActionResult DeleteHospitalClinics(int id)
        {
            _ClinicRep.deleteHospitalClinic(id);
            return Ok();
        }




        [HttpGet("getDoctorid")]
        public IActionResult Getdocctor(int id)
        {
            var Rate = _ClinicRep.GetDoctor(id);
            return Ok(Rate);
        }
        [HttpGet("getoneDoctorid")]
        public IActionResult Getdocctorid(int id)
        {
            var Rate = _ClinicRep.GetDoctorid(id);
            return Ok(Rate);
        }

        [HttpGet("getHospitalid")]
        public IActionResult Getdocctor1(int id)
        {
            var Rate = _ClinicRep.Getthospital(id);
            return Ok(Rate);
        }


        [HttpGet("getHosCilid")]
        public IActionResult Getdoccto2r(int id)
        {
            var Rate = _ClinicRep.GettHosCil(id);
            return Ok(Rate);
        }


        [HttpGet("getClinicid")]
        public IActionResult Getdoccto3r(int id)
        {
            var Rate = _ClinicRep.GettClinic(id);
            return Ok(Rate);
        }

    }
}