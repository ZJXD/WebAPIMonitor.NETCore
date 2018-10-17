using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMonitor.NETCore.WebAPI
{
    public class LogContext : DbContext
    {
        //public string ConnectionString { get; set; }
        //public LogContext(string connectionString)
        //    : base()
        //{
        //    this.ConnectionString = connectionString;
        //}
        //public MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}

        public LogContext(DbContextOptions<LogContext> options)
            : base(options)
        { }

        //public DbSet<application> Applic { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL(@"server=192.168.199.52;port=3306;database=dit_prod_log;uid=dit_prod_log;password=123456");
        //}
    }

    public class application
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string token { get; set; }

        public bool? is_delete { get; set; }
    }
}
