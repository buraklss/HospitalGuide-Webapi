using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Clinics
    {
        public Clinics()
        {
            HospitalClinics = new HashSet<HospitalClinics>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HospitalClinics> HospitalClinics { get; set; }
    }
}
