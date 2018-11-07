using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.GeoTool
{
    /// <summary>
    /// 聚合分析
    /// </summary>
    public class ClusterAnalysis
    {
        private List<Point> points;
        private double Radius;
        private List<Cluster> clusters;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_points">输入点</param>
        /// <param name="radius">半径（米）</param>
        public ClusterAnalysis(List<Point> _points, double radius = 1000)
        {
            this.points = _points;
            this.Radius = radius;
            clusters = new List<Cluster>();
        }

        /// <summary>
        /// 开始分析
        /// </summary>
        /// <returns></returns>
        public List<Cluster> StartAnalysis()
        {
            Cluster cluster = new Cluster()
            {
                CenterPoint = points[0],
                Points = new List<Point>
                {
                    points[0]
                }
            };
            clusters.Add(cluster);

            int n = points.Count;
            // 对所有的点进行遍历
            for (int i = 1; i < n; i++)
            {
                double distance = Radius + 1;
                int clusterIndex = 0;
                // 对已有的进行遍历
                for (int j = 0; j < clusters.Count; j++)
                {
                    double tempDistance = GeoDistance.GetDistance(clusters[j].CenterPoint, points[i]);
                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        clusterIndex = j;
                    }
                }
                if (distance <= Radius)
                {
                    clusters[clusterIndex].Points.Add(points[i]);
                    clusters[clusterIndex].CenterPoint.Latitude = clusters[clusterIndex].Points.Sum(t => t.Latitude) / clusters[clusterIndex].Points.Count;
                    clusters[clusterIndex].CenterPoint.Longitude = clusters[clusterIndex].Points.Sum(t => t.Longitude) / clusters[clusterIndex].Points.Count;
                }
                else
                {
                    cluster = new Cluster()
                    {
                        CenterPoint = points[i],
                        Points = new List<Point>
                        {
                            points[i]
                        }
                    };
                    clusters.Add(cluster);
                }
            }

            return this.clusters;
        }
    }
}
