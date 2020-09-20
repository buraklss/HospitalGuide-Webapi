using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Entities
{
    public class Rates
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string UserId { get; set; }
        public int? Star1 { get; set; }
        public int? Star2 { get; set; }
        public int? Star3 { get; set; }
        public int? Star4 { get; set; }
        public int? Star5 { get; set; }

        public Hospitals Hospital { get; set; }

    }
}
