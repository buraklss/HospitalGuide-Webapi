using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Doctors
    {
        public Doctors()
        {
            AppointmentDays = new HashSet<AppointmentDays>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }
        public int HospitalClinicId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }

        public HospitalClinics HospitalClinic { get; set; }
        public ICollection<AppointmentDays> AppointmentDays { get; set; }
    }
}
