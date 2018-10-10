using System;
using System.Collections.Generic;
using System.Text;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.BLL
{
    public class UnitBLL : IUnitBLL
    {
        public UnitDTO GetUnit()
        {
            UnitDTO item = new UnitDTO
            {
                Id = 1,
                Name = "深度信息",
                TypeName = "企业",
                Address = "绍兴路"
            };

            return item;
        }
    }
}
