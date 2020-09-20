using HospitalGuide.Webapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalGuide.Webapi.Data.Abstract
{
    public interface IUserRepository
    {

        UserInfo GetUser(int ID);
        IEnumerable<UserInfo> GetAllUsers();
        void UpdateUser(UserInfo updateuser, string pass = null);
        void DeleteUser(int id);
        Task<UserInfo> Register(UserInfo user, string Password);
        Task<UserInfo> Login(string Mail,string Password);
        Task<Admins> lAdminlogin(string Mail, string Password);
        Task<bool> Logut(string Mail);
        void HashCreater(string Password, out byte[] passwordhash, out byte[] passwordencoder);
        Boolean ForgetPassword(string mail);
        Boolean ResetPassword(string mail, string password, string code);

    }
}
