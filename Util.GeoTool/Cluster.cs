using System;
using System.Collections.Generic;
using System.Text;

namespace Util.GeoTool
{
    public class Cluster
    {
        /// <summary>
        /// 聚类中心点
        /// </summary>
        public Point CenterPoint { get; set; }

        /// <summary>
        /// 聚集包含的点集
        /// </summary>
        public List<Point> Points { get; set; }
    }
}
