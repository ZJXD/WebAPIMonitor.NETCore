using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.MySQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules;

namespace WebAPIMonitor.NETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly MySQLDatabase mySQLDatabase;

        public LogController(MySQLDatabase mySQLDatabase)
        {
            this.mySQLDatabase = mySQLDatabase;
        }

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ApplicationEntity> GetApp()
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

            List<ApplicationEntity> list = this.mySQLDatabase.FindList<ApplicationEntity>("select * from application").ToList();
            //List<LogEntity> list = this.mysqlDb.FindList<LogEntity>(t => t.IsUntreatedException == false && t.Id < 100).ToList();

            return list;
        }
    }
}