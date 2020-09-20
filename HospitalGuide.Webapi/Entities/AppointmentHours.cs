using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class AppointmentHours
    {
        public AppointmentHours()
        {
            Randevular = new HashSet<Randevular>();
        }

        public int Id { get; set; }
        public int DayId { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }

        public AppointmentDays Day { get; set; }
        public ICollection<Randevular> Randevular { get; set; }
    }
}
