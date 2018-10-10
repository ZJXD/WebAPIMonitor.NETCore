using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL userBLL;

        public UserController(IUserBLL userBLL)
        {
            this.userBLL = userBLL;
        }

        [HttpGet]
        public UserDTO GetUser()
        {
            return userBLL.GetUser();
        }
    }
}