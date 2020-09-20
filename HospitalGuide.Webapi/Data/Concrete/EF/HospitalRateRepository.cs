using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Concrete.EF
{
    public class HospitalRateRepository:IHospitalRateRepository
    {
        private DataContext Context;
        public HospitalRateRepository(DataContext _context)
        {
            Context = _context;
        }

        public decimal getratVALUE(int hospital)
        {
            decimal send = 0;
            var starts = Context.Rates.FirstOrDefault(a => a.HospitalId == hospital);
            if (starts != null)
            {
                decimal s11 = Convert.ToDecimal(starts.Star1);
                decimal s22 = Convert.ToDecimal(starts.Star2);
                decimal s33 = Convert.ToDecimal(starts.Star3);
                decimal s44 = Convert.ToDecimal(starts.Star4);
                decimal s55 = Convert.ToDecimal(starts.Star5);
                decimal verilenoy = s11 + s22 + s33 + s44 + s55;
                decimal s1 = Convert.ToDecimal(starts.Star1 * 1);
                decimal s2 = Convert.ToDecimal(starts.Star2 * 2);
                decimal s3 = Convert.ToDecimal(starts.Star3 * 3);
                decimal s4 = Convert.ToDecimal(starts.Star4 * 4);
                decimal s5 = Convert.ToDecimal(starts.Star5 * 5);
                decimal toplam = s1 + s2 + s3 + s4 + s5;
                Console.WriteLine(toplam);
                Console.WriteLine(verilenoy);
                decimal sonuc = Convert.ToDecimal(toplam / verilenoy);
                send = Math.Round(sonuc, 2);
            }
           
    


            if (send == 0 && send == null)
            {
                send = 0;
            }
            return send;


        }

        public void addrate(int hospital, int rate, string user)
        {
            Rates hid = Context.Rates.FirstOrDefault(a => a.HospitalId == hospital);

            if (hid != null)
            {
                string Olduser = hid.UserId;
                string deger = "yok";
                Console.WriteLine(Olduser);


                int? star1 = hid.Star1;
                int? star2 = hid.Star2;
                int? star3 = hid.Star3;
                int? star4 = hid.Star4;
                int? star5 = hid.Star5;
                var arr = Olduser.Split(',');
                Console.WriteLine(arr.Length);
                for (int i = 0; i <= arr.Length - 1; i++)
                {
                    if (arr[i] == user)
                    {
                        deger = "var";
                    }

                }

                if (deger == "yok")
                {
                    hid.UserId = Olduser + "," + user;
                    if (rate == 1)
                    {
                        hid.Star1 = 1 + star1;
                    }

                    if (rate == 2)
                    {
                        hid.Star2 = 1 + star2;
                    }

                    if (rate == 3)
                    {
                        hid.Star3 = 1 + star3;
                    }

                    if (rate == 4)
                    {
                        hid.Star4 = 1 + star4;
                    }

                    if (rate == 5)
                    {
                        hid.Star5 = 1 + star5;
                    }
                }

                Context.SaveChanges();
            }
            else
            {

                string Olduser = user;
               
        

         var ratetable = new Rates();
                ratetable.UserId = user;
                ratetable.HospitalId = hospital;
                ratetable.Star1 = 0;
                ratetable.Star2 = 0;
                ratetable.Star3 = 0;
                ratetable.Star4 = 0;
                ratetable.Star5 = 0;

                if (rate == 1)
                    {
                        ratetable.Star1 = 1;
                    }

                    if (rate == 2)
                    {
                        ratetable.Star2 = 1;
                    }

                    if (rate == 3)
                    {
                        ratetable.Star3 = 1;
                    }

                    if (rate == 4)
                    {
                        ratetable.Star4 = 1;
                    }

                    if (rate == 5)
                    {
                        ratetable.Star5 = 1;
                    }

                Context.Rates.Add(ratetable);
                Context.SaveChanges();





            }
        }

        public Rates getrate(int hospital)
        {
            return Context.Rates.FirstOrDefault(a => a.HospitalId == hospital);
        }
    }

}

