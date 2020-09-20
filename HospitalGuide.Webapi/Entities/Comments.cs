using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Comments
    {
        public Comments()
        {
            CommentTime = DateTime.Now;
        }
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentTime { get; set; }
        public int HospitalId { get; set; }
        public int UserId { get; set; }

        public Hospitals Hospital { get; set; }
        public UserInfo User { get; set; }
    }
}
