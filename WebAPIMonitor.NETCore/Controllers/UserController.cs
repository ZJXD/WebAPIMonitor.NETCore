using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMonitor.BLL;
using WebAPIMonitor.Model;

namespace WebAPIMonitor.NETCore.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        private readonly UserBLL userBLL = new UserBLL();

        [HttpGet]
        public UserDTO GetUser()
        {
            return userBLL.GetUser();
        }
    }
}