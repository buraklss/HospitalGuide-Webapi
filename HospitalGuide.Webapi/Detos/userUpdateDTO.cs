using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Detos
{
    public class userUpdateDTO
    {
        public int Id { get; set; }
        public string PassId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Mail { get; set; }
        public string Citizenship { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public byte[] Passwordencoder { get; set; }
        public byte[] Passwordhash { get; set; }

    }
}
