using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Randevular
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HourId { get; set; }

        public AppointmentHours Hour { get; set; }
        public UserInfo User { get; set; }
    }
}
