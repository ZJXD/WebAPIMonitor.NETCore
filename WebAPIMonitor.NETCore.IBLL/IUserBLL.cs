﻿using System;
using System.Collections.Generic;
using System.Text;
using WebAPIMonitor.NETCore.Entity;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.IBLL
{
    public interface IUserBLL
    {

        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <returns></returns>
        List<SysUserEntity> GetAllUser();

        UserDTO GetUser();
    }
}
