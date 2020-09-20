using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Detos
{
    public class hospitalDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public  string District { get; set; }
        public  string Location { get; set; }
        public  string Name { get; set; }
        public  string Phone { get; set; }
        public string Harita { get; set; }
    }
}
