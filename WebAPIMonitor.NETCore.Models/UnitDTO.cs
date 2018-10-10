using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIMonitor.NETCore.Models
{
    /// <summary>
    /// 部门实体类
    /// </summary>
    public class UnitDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public string Address { get; set; }
    }
}
