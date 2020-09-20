using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Hospitals
    {
        public Hospitals()
        {
            Comments = new HashSet<Comments>();
            HospitalClinics = new HashSet<HospitalClinics>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Harita { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<HospitalClinics> HospitalClinics { get; set; }
        public Rates Rate { get; set; }
    }
}
