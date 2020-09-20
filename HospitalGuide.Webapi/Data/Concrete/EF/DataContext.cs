using HospitalGuide.Webapi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Concrete.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {

        }
        public DbSet<UserInfo> UserInfo { get; set; }//Control+. Add using
        public DbSet<Country> Country { get; set; }
        public DbSet<Citiess> Cities { get; set; }
        public DbSet<Hospitals> Hospitals{ get; set; }
        public DbSet<Clinics> Clinics { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<AppointmentDays> AppointmentDays { get; set; }
        public DbSet<AppointmentHours> AppointmentHours { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Randevular> Randevular { get; set; }
        public DbSet<HospitalClinics> HospitalClinics { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}
