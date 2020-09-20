using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class AppointmentDays
    {
        public AppointmentDays()
        {
            AppointmentHours = new HashSet<AppointmentHours>();
            
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public bool Status { get; set; }

        public Doctors Doctor { get; set; }
        public ICollection<AppointmentHours> AppointmentHours { get; set; }
       
    }
}
