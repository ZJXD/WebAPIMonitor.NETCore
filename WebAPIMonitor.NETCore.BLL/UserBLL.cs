using System;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.BLL
{
    public class UserBLL:IUserBLL
    {
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
