using DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIMonitor.NETCore.Entity;
using WebAPIMonitor.NETCore.IService;

namespace WebAPIMonitor.NETCore.Service
{
    public class UserService : SqlSugarDatabase, IUserService
    {
        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <returns></returns>
        public List<SysUserEntity> GetUser()
        {
            return Database.Queryable<SysUserEntity>().ToList();
        }
    }
}
