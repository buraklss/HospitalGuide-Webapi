using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Data.Concrete.EF;
using HospitalGuide.Webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HospitalGuide.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/AppSystem")]
    public class AppSystemController : Controller
    {
       
        private IAppointmentRepository _AppSystem;
        
        
        public AppSystemController(IAppointmentRepository appsystem)
        {
          
            _AppSystem = appsystem;
        }




        [HttpGet("getOneDay")]
        public IActionResult GetallHour1s(int id)
        {
            var AppHours = _AppSystem.getOneDay(id);
            return Ok(AppHours);
        }

        [HttpGet("getOneHour")]
        public IActionResult GetallHou2rs(int id)
        {
            var AppHours = _AppSystem.getoneHour(id);
            return Ok(AppHours);
        }



        [HttpGet("allDays")]
        public IActionResult GetallHours()
        {
            var AppHours = _AppSystem.AllDays();
            return Ok(AppHours);
        }
        [HttpGet("allhourss")]
        public IActionResult GetallHourss()
        {
            var AppHours = _AppSystem.AllHours();
            return Ok(AppHours);
        }



        [HttpGet("allDaystrue")]
        public IActionResult GetalltrueHours()
        {
            var AppHours = _AppSystem.GetAllDaystrue();
            return Ok(AppHours);
        }
        [HttpGet("allhourstrue")]
        public IActionResult GetallHourstrue()
        {
            var AppHours = _AppSystem.GetAllHourstrue();
            return Ok(AppHours);
        }


        [HttpGet("DaysinDoctoridAndBool")]
        public IActionResult GetDays(int doctor,bool status)
        {
            var AppDays = _AppSystem.GetDays(doctor, status);
            return Ok(AppDays);
        }
        [HttpGet("HoursinDayidAndBool")]
        public IActionResult GetHours(int day, bool status)
        {
            var AppHours = _AppSystem.GetHours(day, status);
            return Ok(AppHours);
        }


        [HttpGet("allDaysIndoctorid")]
        public IActionResult GetallDays(int doctor)
        {
            var AppDays = _AppSystem.GetAllDays(doctor);
            return Ok(AppDays);
        }
        [HttpGet("allHoursInDayid")]
        public IActionResult GetallHourss(int day)
        {
            var AppHours = _AppSystem.GetAllHours(day);
            return Ok(AppHours);
        }
        [HttpGet("UserRandevu")]
        public IActionResult GetRandevu(int user)
        {
            var randevu = _AppSystem.GetRandevu(user);
            return Ok(randevu);
        }
        [HttpGet("GetAllRandevu")]
        public IActionResult GetAllRandevu()
        {
            var randevu = _AppSystem.AllRandevu();
            return Ok(randevu);
        }

        [HttpPost("addappday")]
        public IActionResult AddAppDay([FromBody]AppointmentDays add)
        {
            _AppSystem.addAppDay(add);
            return Ok(add);
        }
        [HttpPut("updateappday")]
        public IActionResult UpdateAppDay([FromBody]AppointmentDays update)
        {
            _AppSystem.updateAppDay(update);
            return Ok(update);
        }
        [HttpDelete("deleteappday")]
        public IActionResult deleteAppDay(int id)
        {
            _AppSystem.deleteAppDay(id);
            return Ok();
        }

        [HttpPost("addapphour")]
        public IActionResult AddAppHour([FromBody]AppointmentHours add)
        {
            _AppSystem.addAppHour(add);
            return Ok(add);
        }

        [HttpPost("addOTOapphour")]
        public IActionResult AdotoAppHour([FromBody]AppointmentHours add)
        {
            _AppSystem.addOTOAppHour(add);
            return Ok(add);
        }
        [HttpPut("updateapphour")]
        public IActionResult UpdateAppHour([FromBody]AppointmentHours update)
        {
            _AppSystem.updateAppHour(update);
            return Ok(update);
        }
        [HttpDelete("deleteapphour")]
        public IActionResult deleteAppHour(int id)
        {
            _AppSystem.deleteAppHour(id);
            return Ok();
        }

        [HttpPost("addrandevu")]
        public IActionResult AddRandevu([FromBody]Randevular add)
        {
            _AppSystem.addRandevu(add);
            return Ok(add);
        }
        [HttpPut("updaterandevu")]
        public IActionResult UpdateRandevu([FromBody]Randevular update)
        {
            _AppSystem.updateRandevu(update);
            return Ok(update);
        }
        [HttpDelete("deleterandevu")]
        public IActionResult deleteRandevu(int id)
        {
            _AppSystem.deleteRandevu(id);
            return Ok(id);
        }
    }
}