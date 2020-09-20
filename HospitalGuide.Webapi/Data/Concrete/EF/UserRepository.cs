using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace HospitalGuide.Webapi.Data.Concrete.EF
{
    public class UserRepository : IUserRepository
    {
        private DataContext Context;

        public UserRepository(DataContext _Context)
        {
            Context = _Context;
        }

        public UserInfo GetUser(int ID)
        {
            return Context.UserInfo.Find(ID);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return Context.UserInfo;
        }

        public void UpdateUser(UserInfo updateuser, string pass=null)
        {

            var user = Context.UserInfo.AsNoTracking().SingleOrDefault(a => a.Id == updateuser.Id);

            var oldpasswpordhash = user.Passwordhash;
            var oldpassencode = user.Passwordencoder;
            if (pass != null && pass !="string")
            {
                byte[] passwordhash;
                byte[] passwordencoder;
                HashCreater(pass, out passwordhash, out passwordencoder);
                updateuser.Passwordhash = passwordhash;
                updateuser.Passwordencoder = passwordencoder;

                Context.UserInfo.Update(updateuser);
                Context.SaveChanges();
            }
            else
            {
                updateuser.Passwordencoder =  oldpassencode;
                updateuser.Passwordhash = oldpasswpordhash;
                Context.UserInfo.Update(updateuser);
                Context.SaveChanges();
            }
          
        }

        public void DeleteUser(int id)
        {
            var user = Context.UserInfo.Find(id);
            Context.UserInfo.Remove(user);
            Context.SaveChanges();
        }

        public async Task<UserInfo> Login(string Mail, string Password)
        {
            var User = await Context.UserInfo.FirstOrDefaultAsync(x => x.Mail == Mail);
            if (User != null)
            {
                if (!PasswordHashVerify(Password, User.Passwordhash, User.Passwordencoder))
                {
                    return null;
                }

                return User;
            }

            return null;
        }

        public async Task<Admins> lAdminlogin(string Mail, string Password)
        {
            var User = await Context.Admins.FirstOrDefaultAsync(x => x.Mail == Mail);
            if (User != null)
            {
                if (User.Password != Password)
                {
                    return null;
                }

                return User;
            }

            return null;
        }

        private bool PasswordHashVerify(string Password, byte[] passwordhash, byte[] passwordencoder)
        {
            using (var decoder = new System.Security.Cryptography.HMACSHA512(passwordencoder))
            {
                var hash = decoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != passwordhash[i])
                    {
                        return false;
                    }
                }

                return true;
            }

        }

        public async Task<bool> Logut(string Mail)
        {
            if (await Context.UserInfo.AnyAsync(x => x.Mail == Mail))
            {
                return true;
            }

            return false;
        }

        public async Task<UserInfo> Register(UserInfo user, string Password)
        {
            byte[] passwordhash;
            byte[] passwordencoder;
            HashCreater(Password, out passwordhash, out passwordencoder);
            user.Passwordhash = passwordhash;
            user.Passwordencoder = passwordencoder;
            await Context.UserInfo.AddAsync(user);
            await Context.SaveChangesAsync();
            return user;
        }

        public void HashCreater(string Password, out byte[] passwordhash, out byte[] passwordencoder)
        {
            using (var decoder = new System.Security.Cryptography.HMACSHA512())
            {
                passwordhash = decoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                passwordencoder = decoder.Key;
            }
        }

        public bool ForgetPassword(string mail)
        {

            var user = Context.UserInfo.SingleOrDefault(a => a.Mail == mail);
            if (user != null)
            {

                var userinfo =  mail+"&code="+ RandomString(20);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Hospital Guide", "rss_0@outlook.com"));
                message.To.Add(new MailboxAddress(mail, mail ));
                message.Subject = "Reset Password Link";
                message.Body = new TextPart("Html")
                {
                    Text =( "hello "+mail + "<br><br><br>" + "Reset Password Link:"  + "<br><br>" +
                            "http://localhost:4200/resetpassword/" +mail    
                   )
                    
                     
                };


                using ( var client = new SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587,false );
                    client.Authenticate("rss_0@outlook.com", "123gm123");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }

            return false;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public bool ResetPassword(string mail,  string password, string code = "DFDGDF345GNhfgh456457")
        {

            var user = Context.UserInfo.SingleOrDefault(a => a.Mail == mail);
            
            if (user != null)
            {
                byte[] passwordhash;
                byte[] passwordencoder;
                HashCreater(password, out passwordhash, out passwordencoder);
                user.Passwordhash = passwordhash;
                user.Passwordencoder = passwordencoder;

                Context.Update(user);
                Context.SaveChanges();




                var userinfo = mail;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Hospital Guide", "rss_0@outlook.com"));
                message.To.Add(new MailboxAddress(mail, mail));
                message.Subject = "Reset Password Link";
                message.Body = new TextPart("Html")
                {
                    Text = ("Password is changed")


                };


                using (var client = new SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587, false);
                    client.Authenticate("rss_0@outlook.com", "123gm123");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }

            return false;
        }
    }
}
