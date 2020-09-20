using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class HospitalClinics
    {
        public HospitalClinics()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int HospitalId { get; set; }

        public Clinics Clinic { get; set; }
        public Hospitals Hospital { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
    }
}
