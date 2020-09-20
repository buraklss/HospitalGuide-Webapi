using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Data.Concrete.EF;
using HospitalGuide.Webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGuide.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Country")]
    public class CountryController : Controller
    {
        private ICountryRepository Context;
        public CountryController(ICountryRepository _Context)
        {
            Context = _Context;
        }

        [HttpGet("searchcountry")]
        public IActionResult Searchcountry(string Country)
        {
            var result = Context.SearchCountry(Country);
            return Ok(result);
        }

        [HttpGet("searchcity")]
        public IActionResult Searchcity(string city, string country)
        {
            var result = Context.SearchCity(city, country);
            return Ok(result);
        }

        [HttpGet("getcountrid")]
        public IActionResult Cities1(int id)
        {
            var cities = Context.getonecounrty(id);
            return Ok(cities);
        }
        [HttpGet("getcitid")]
        public IActionResult counrt1(int id)
        {
            var cities = Context.getonecitie(id);
            return Ok(cities);
        }


        [HttpGet("cinfo")]
        public IActionResult Country()
        {
            var country = Context.GetCountry();
            return Ok(country);
        }
        [HttpGet("cities")]
        public IActionResult Cities(string Country)
        {
            var cities = Context.Getcities(Country);
            return Ok(cities);
        }
        [HttpGet("allcities")]
        public IActionResult Citiess()
        {
            var cities = Context.GetallCities();
            return Ok(cities);
        }

        [HttpGet("getaf")]
        public IActionResult getaf(string Country)
        {
            var cities = Context.GetcityAF(Country);
            return Ok(cities);
        }
        [HttpGet("getgl")]
        public IActionResult getgl(string Country)
        {
            var cities = Context.GetcityGL(Country);
            return Ok(cities);
        }
        [HttpGet("getms")]
        public IActionResult getms(string Country)
        {
            var cities = Context.GetcityMS(Country);
            return Ok(cities);
        }
        [HttpGet("gettz")]
        public IActionResult gettz(string Country)
        {
            var cities = Context.GetcityTZ(Country);
            return Ok(cities);
        }
        [HttpGet("getqwx")]
        public IActionResult getqwx(string Country)
        {
            var cities = Context.GetcityQWX(Country);
            return Ok(cities);
        }

        [HttpPost("addcountry")]
        public IActionResult AddCountry([FromBody]Country isimver)
        {
            if (isimver.Flagimage != null &&isimver.Name !=null && isimver.Routerlink!=null)
            {
                Context.addCountry(isimver);
                return Ok(isimver);
            }

            return StatusCode(400);
        }
        [HttpPut("updatecountry")]
        public IActionResult UpdateCountry([FromBody]Country update)
        {
            Context.updateCountry(update);
            return Ok(update);
        }
        [HttpDelete("deletecountry")]
        public IActionResult deleteCountry(int id)
        {
            Context.deleteCountry(id);
            return Ok();
        }

        [HttpPost("addcity")]
        public IActionResult AddCity([FromBody]Citiess add)
        {
            Context.addCities(add);
            return Ok(add);
        }
        [HttpPut("updatecity")]
        public IActionResult UpdateCity([FromBody]Citiess update)
        {
            Context.updateCities(update);
            return Ok(update);
        }
        [HttpDelete("deletecity")]
        public IActionResult deleteCity(int id)
        {
            Context.deleteCities(id);
            return Ok();
        }



    }
}