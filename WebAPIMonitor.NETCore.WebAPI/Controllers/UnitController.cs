using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMonitor.NETCore.IBLL;
using WebAPIMonitor.NETCore.Models;

namespace WebAPIMonitor.NETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBLL unitBLL;

        public UnitController(IUnitBLL unitBLL)
        {
            this.unitBLL = unitBLL;
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public UnitDTO GetUnit()
        {
            return this.unitBLL.GetUnit();
        }
    }
}