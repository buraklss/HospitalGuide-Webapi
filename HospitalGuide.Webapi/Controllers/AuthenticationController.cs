using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Detos;
using HospitalGuide.Webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalGuide.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthenticationController : Controller
    {
        private IUserRepository user_REP;
       
        private IConfiguration iconfiguration;
        private IMapper mapper;
        
        public AuthenticationController(IUserRepository _user_REP,IConfiguration _configuration, IMapper _mapper)
        {
            user_REP = _user_REP;
            iconfiguration = _configuration;
            mapper = _mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]userRegisterDTO userRegister)
        {
            if (await user_REP.Logut(userRegister.Mail))
            {
                ModelState.AddModelError("Mail", "Mail already exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create_user = new UserInfo { Mail = userRegister.Mail, PassId = userRegister.PassID, Name = userRegister.Name, Surname = userRegister.Surname, Gender = userRegister.Gender, Citizenship = userRegister.Citizenship, Phone = userRegister.Phone };

            var created_user = await user_REP.Register(create_user, userRegister.Password);

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]userLoginDTO userLogin)
        {
            var user = await user_REP.Login(userLogin.Mail,userLogin.Password);
            var Token = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(iconfiguration.GetSection("AppSettings:Token").Value);
            if (user==null)
            {
                return Unauthorized();

            }
            var TokenThis = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                  new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                  new Claim(ClaimTypes.Name,user.Mail)
              }),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

            };
            var CreateTokennn = Token.CreateToken(TokenThis);
            var TokenString = Token.WriteToken(CreateTokennn);
            var UserId = user.Id;
         
            return Ok(TokenString+"?"+UserId);
        }

        [HttpPost("Adminlogin")]
        public async Task<IActionResult> adminLogin([FromBody]userLoginDTO userLogin)
        {
            var user = await user_REP.lAdminlogin(userLogin.Mail, userLogin.Password);
            var Token = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(iconfiguration.GetSection("AppSettings:Token").Value);
            if (user == null)
            {
                return Unauthorized();

            }
            var TokenThis = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Mail)
                }),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

            };
            var CreateTokennn = Token.CreateToken(TokenThis);
            var TokenString = Token.WriteToken(CreateTokennn);
            var UserId = user.Id;

            return Ok(TokenString + "?" + UserId);
        }


        [HttpPut("userupdate")]
        public IActionResult userup([FromBody]userRegisterDTO userUpdate)
        {

            
            var userups = mapper.Map<UserInfo>(userUpdate);
           
            user_REP.UpdateUser(userups, userUpdate.Password);
           
            return Ok(userUpdate);

        }

        [HttpDelete("userdelete")]
        public IActionResult userdelete(int id)
        {
            user_REP.DeleteUser(id);

            return StatusCode(200);

        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(int id)
        {

            var user = user_REP.GetUser(id);
            var usermap = mapper.Map<userRegisterDTO>(user);
           return Ok(usermap);
        }

        [HttpGet("ForgetPassword")]
        public IActionResult forgetPassword(string mail)
        {

            var user = user_REP.ForgetPassword(mail);
            
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult gellall()
        {

            var user = user_REP.GetAllUsers();
            var usermap = mapper.Map<List<userRegisterDTO>>(user);
            return Ok(usermap);
        }

        [HttpGet("ResertPassword")]
        public IActionResult resetPassword(string mail ,string pass)
        {

            var user = user_REP.ResetPassword(mail,pass,"sdkjfhsdkfssdfs45346");

            return Ok(user);
        }

    }
}