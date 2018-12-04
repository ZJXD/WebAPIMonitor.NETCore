using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.MySQL;
using Microsoft.AspNetCore.Mvc;
using Util.GeoTool;

namespace WebAPIMonitor.NETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MySQLDatabase mysqlDb;

        public ValuesController(MySQLDatabase mySQLDatabase)
        {
            this.mysqlDb = mySQLDatabase;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Cluster>> Get()
        {
            //return new string[] { "value1", "value2" };

            string str_SQL = @"
SELECT
	DISTINCT(c.latitude) AS Latitude,c.longitude AS Longitude
FROM
	gps_history_coord c 
WHERE
	c.latitude IS NOT NULL 
	AND c.latitude > 30 
	AND c.satellite_time >= '2018-01-02 09:00:00'
	AND c.satellite_time <= '2018-01-02 10:00:00' ";
            List<Point> points = this.mysqlDb.FindList<Point>(str_SQL).ToList();

            ClusterAnalysis clusterAnalysis = new ClusterAnalysis(points, 50);
            var result = clusterAnalysis.StartAnalysis().Where(t => t.Points.Count > 1).ToList();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value22222222";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
