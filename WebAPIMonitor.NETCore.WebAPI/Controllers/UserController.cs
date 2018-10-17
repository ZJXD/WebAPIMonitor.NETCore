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

namespace WebAPIMonitor.NETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL userBLL;
        //private readonly LogContext _context;
        private readonly MySQLDatabase mysqlDb;

        public UserController(IUserBLL userBLL, MySQLDatabase mysqlDb)
        {
            this.userBLL = userBLL;
            this.mysqlDb = mysqlDb;
        }

        //[HttpGet]
        //public UserDTO GetUser()
        //{
        //    return userBLL.GetUser();
        //}

        [HttpGet]
        public List<LogEntity> GetApp()
        {
            //List<application> list = new List<application>();
            //连接数据库
            //using (MySqlConnection msconnection = _context.GetConnection())
            //{
            //    msconnection.Open();
            //    //查找数据库里面的表
            //    MySqlCommand mscommand = new MySqlCommand("select * from application", msconnection);
            //    using (MySqlDataReader reader = mscommand.ExecuteReader())
            //    {
            //        //读取数据
            //        while (reader.Read())
            //        {
            //            list.Add(new application()
            //            {
            //                id = int.Parse(reader.GetString("id")),
            //                name = reader.GetString("name"),
            //                token = reader.GetString("token")
            //            });
            //        }
            //    }
            //}

            //_context.Database.EnsureCreated();
            //List<application> aap = _context.Query<application>("select * from application").ToList();

            //List<application> list = this.mysqlDb.FindList<application>("select * from application").ToList();
            List<LogEntity> list = this.mysqlDb.FindList<LogEntity>(t => t.Id < 100).ToList();

            return list;
        }
    }
}