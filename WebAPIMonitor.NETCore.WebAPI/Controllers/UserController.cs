using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.Models;
using Dapper;
using DataBase.MySQL;
using Modules;
using WebAPIMonitor.NETCore.Entity;

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
        public List<SysUserEntity> GetUser()
        {
            return userBLL.GetAllUser();
        }
    }
}