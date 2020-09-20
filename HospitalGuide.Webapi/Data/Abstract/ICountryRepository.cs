using HospitalGuide.Webapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Abstract
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountry();
        IEnumerable<Citiess> GetcityAF(string country);
        IEnumerable<Citiess> GetcityGL(string country);
        IEnumerable<Citiess> GetcityMS(string country);
        IEnumerable<Citiess> GetcityTZ(string country);
        IEnumerable<Citiess> GetcityQWX(string country);
        IEnumerable<Citiess> GetallCities();
        IEnumerable<Citiess> Getcities(string country);
        IEnumerable<Country> SearchCountry(string country);
        IEnumerable<Citiess> SearchCity(string city, string country);
        void addCountry(Country newCountry);

        void updateCountry(Country update);

        void deleteCountry(int delete);


        void addCities(Citiess newCountry);

        void updateCities(Citiess update);

        void deleteCities(int delete);

       Country getonecounrty(int id);
       Citiess getonecitie(int id );

    }
}
