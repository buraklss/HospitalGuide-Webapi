using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Detos
{
    public class doctorDTO
    {
        public int ID { get; set; }
        public string Gender { get; set; }
        public int HospitalClinicId  { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }

    }
}
