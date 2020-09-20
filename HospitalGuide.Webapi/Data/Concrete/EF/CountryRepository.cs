using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Concrete.EF
{
    [Produces("application/json")]
    [Route("api/Country")]

    public class CountryRepository : ICountryRepository
    {
        private DataContext Context;
        public IEnumerable<Country> SearchCountry(string country)
        {
            var result = Context.Country.Where(a => a.Name.Contains(country)).OrderBy(a => a.Name);
            return result;
        }

        public IEnumerable<Citiess> SearchCity(string city, string country)
        {
            var result = Context.Cities.Where(a => a.Name.Contains(city) && a.Country == country).OrderBy(a => a.Name);
            return result;
        }

        public CountryRepository(DataContext _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Country> GetCountry()
        {
            return Context.Country;
        }

        public IEnumerable<Citiess> Getcities(string testvalue)
        {
            var cities = Context.Cities.Where(a => a.Country == testvalue).OrderBy(a=>a.Name) ;
            return cities;
        }

        public void addCountry(Country newCountry)
        {
            Context.Country.Add(newCountry);
            Context.SaveChanges();
        }

        public void updateCountry(Country update)
        {
            Context.Country.Update(update);
            Context.SaveChanges();
        }

        public void deleteCountry(int delete)
        {
            var giris = Context.Country.Find(delete);
            Context.Country.Remove(giris);
            Context.SaveChanges();
        }

        public void addCities(Citiess add)
        {
            Context.Cities.Add(add);
            Context.SaveChanges();
        }

        public void updateCities(Citiess update)
        {
            Context.Cities.Update(update);
            Context.SaveChanges();
        }

        public void deleteCities(int delete)
        {
            var giris = Context.Cities.Find(delete);
            Context.Cities.Remove(giris);
            Context.SaveChanges();
        }

        public Country getonecounrty(int id)
        {
            return Context.Country.Find(id);
        }

        public Citiess getonecitie(int id)
        {
            return Context.Cities.Find(id);
        }

        public IEnumerable<Citiess> GetcityAF(string country)
        {

            var res = Context.Cities.Where(a=>a.Name.StartsWith("A") || a.Name.StartsWith("B") || a.Name.StartsWith("C") || a.Name.StartsWith("D") || a.Name.StartsWith("E") || a.Name.StartsWith("F") && a.Country == country);
            return res.Where(a => a.Country == country);
        }

        public IEnumerable<Citiess> GetcityGL(string country)
        {
            var res = Context.Cities.Where(a => a.Name.StartsWith("G") || a.Name.StartsWith("H") || a.Name.StartsWith("I") || a.Name.StartsWith("J") || a.Name.StartsWith("K") || a.Name.StartsWith("L") && a.Country == country);
            return res.Where(a => a.Country == country);
        }

        public IEnumerable<Citiess> GetcityMS(string country)
        {
            var res = Context.Cities.Where(a => a.Name.StartsWith("M") || a.Name.StartsWith("N") || a.Name.StartsWith("O") || a.Name.StartsWith("P") || a.Name.StartsWith("R") || a.Name.StartsWith("S") && a.Country == country);
            return res.Where(a => a.Country == country);
        }

        public IEnumerable<Citiess> GetcityTZ(string country)
        {
            var res = Context.Cities.Where(a => a.Name.StartsWith("T") || a.Name.StartsWith("U") || a.Name.StartsWith("V") || a.Name.StartsWith("Y") || a.Name.StartsWith("Z") && a.Country == country);
            return res.Where(a => a.Country == country);
        }

        public IEnumerable<Citiess> GetcityQWX(string country)
        {
            var res = Context.Cities.Where(a => a.Name.StartsWith("Q") || a.Name.StartsWith("W") || a.Name.StartsWith("X") && a.Country == country);
            return res.Where(a => a.Country == country);
        }

        public IEnumerable<Citiess> GetallCities()
        {
            var res = Context.Cities;
            return res;
        }
    }
}
