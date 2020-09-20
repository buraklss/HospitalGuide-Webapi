using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HospitalGuide.Webapi.Data.Concrete.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGuide.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/isActive")]
   
    public class ValuesController:Controller
    {
        [HttpGet("is")]
        public OkObjectResult get()
        {
            
            return Ok(true);
        }


    }

}
