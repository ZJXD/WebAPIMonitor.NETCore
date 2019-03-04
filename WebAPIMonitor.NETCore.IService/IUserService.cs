using System;
using System.Collections.Generic;
using System.Text;
using WebAPIMonitor.NETCore.Entity;

namespace WebAPIMonitor.NETCore.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <returns></returns>
        List<SysUserEntity> GetUser();
    }
}
