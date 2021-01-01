using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Panda.API.Service.Controllers
{
    [Route("panda.data/global")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        [HttpGet("confirmed")]
        public IActionResult Confirmed(string date_from, string date_to, 
            string contient, string region, string country)
        {

            return Ok("{ confirmed : 123, date_from : " + date_from + ", date_to : 26 Dec 2020 }"); 
        }
    }
}
