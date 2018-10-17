//using Microsoft.EntityFrameworkCore;
//using MySql.Data.MySqlClient;
using DataBase.Mapping;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataBase.MySQL
{
    public class DatabaseContext : DbContext
    {
        //public string ConnectionString { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            //this.ConnectionString = connectionString;
        }
        //public MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}

        #region 重载
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database.SetInitializer<DatabaseContext>(null);

            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DataBase.dll", "Modules.dll").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            //var typesToRegister = asm.GetTypes()
            //.Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
            //.Where(type => type.GetTypeInfo().IsClass)
            //.Where(type => type.GetTypeInfo().BaseType != null).ToList();
            //foreach (var type in typesToRegister)
            //{
            //    if (modelBuilder.Model.FindEntityType(type) != null)
            //    {
            //        continue;
            //    }

            //    modelBuilder.Model.AddEntityType(type);
            //}

            //modelBuilder.ApplyConfiguration(new ApplicationMap());

            base.OnModelCreating(modelBuilder);

            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DataBase.dll", "Mapping.dll").Replace("file:///", "");
            Assembly asm = Assembly.LoadFile(assembleFileName);
            modelBuilder.AddEntityConfigurationsFromAssembly(asm);
        }
        #endregion
    }
}
