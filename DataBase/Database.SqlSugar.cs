using DataBase.MySQL;
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class SqlSugarDatabase
    {
        public static string DBConnectionString { get; set; }

        public static SqlSugarClient Database
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DBConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
                IsShardSameThread = true
            }
            );
        }

        //public SqlSugarDatabase(string connString)
        //{
        //    Client = new SqlSugarClient(new ConnectionConfig()
        //    {
        //        ConnectionString = connString,
        //        DbType = DbType.MySql,
        //        InitKeyType = InitKeyType.Attribute,    //从特性读取主键和自增列信息
        //        IsAutoCloseConnection = true,           //开启自动释放模式和EF原理一样我就不多解释了

        //    });

        //    //调式代码 用来打印SQL 
        //    Client.Aop.OnLogExecuting = (sql, pars) =>
        //    {
        //        Console.WriteLine(sql + "\r\n" +
        //            Client.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
        //        Console.WriteLine();
        //    };

        //    //var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        //    //optionBuilder.UseMySql(connString, mysqlOptions =>
        //    //{
        //    //    mysqlOptions.ServerVersion(new Version(5, 7, 22), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
        //    //});
        //    //dbcontext = new DatabaseContext(optionBuilder.Options);
        //}

        /////// <summary>
        /////// 获取 当前使用的数据访问上下文对象
        /////// </summary>
        ////public DbContext dbcontext { get; set; }

        ////注意：不能写成静态的
        //public SqlSugarClient Client;//用来处理事务多表查询和复杂的操作
    }
}
