using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Admins
    {

        public int Id { get; set; }
        public string Gender { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }

    }
}
