using System;
using System.Collections.Generic;
using System.Text;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.IBLL
{
    public interface IUserBLL
    {
        UserDTO GetUser();
    }
}
