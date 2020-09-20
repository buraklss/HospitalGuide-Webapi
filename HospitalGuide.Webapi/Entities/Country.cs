using System;
using System.Collections.Generic;

namespace HospitalGuide.Webapi.Entities
{
    public partial class Country
    {
        public int Id { get; set; }
        public string FlagUrl { get; set; }
        public string Flagimage { get; set; }
        public string Name { get; set; }
        public string Routerlink { get; set; }
    }
}
