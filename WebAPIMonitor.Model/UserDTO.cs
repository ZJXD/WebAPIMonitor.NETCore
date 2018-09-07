using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIMonitor.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }
    }
}
