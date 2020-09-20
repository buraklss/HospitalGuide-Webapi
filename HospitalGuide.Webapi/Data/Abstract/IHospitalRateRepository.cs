using HospitalGuide.Webapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Abstract
{
    public interface IHospitalRateRepository
    {
        Rates getrate(int hospital);
        decimal getratVALUE(int hospital);
        void addrate(int hospital,int rate,string user);
    }
}
