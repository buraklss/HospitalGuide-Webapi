using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Comments = new HashSet<Comments>();
            Randevular = new HashSet<Randevular>();
        }

        public int Id { get; set; }
        public string Citizenship { get; set; }
        public string Gender { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string PassId { get; set; }
        public byte[] Passwordencoder { get; set; }
        public byte[] Passwordhash { get; set; }
        public int Phone { get; set; }
        public string Surname { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Randevular> Randevular { get; set; }
    }
}
