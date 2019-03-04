using System;
using System.Collections.Generic;
using WebAPIMonitor.NETCore.Entity;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.IService;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserService userService;

        public UserBLL(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <returns></returns>
        public List<SysUserEntity> GetAllUser()
        {
            return this.userService.GetUser();
        }

        public UserDTO GetUser()
        {
            UserDTO item = new UserDTO()
            {
                Id = 0,
                Name = "张三",
                Age = 23,
                Birthday = DateTime.Parse("1995-10-09 10:20:15"),
                Phone = "1591235745",
                Sex = "男"
            };

            return item;
        }
    }
}
