using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.GeoTool
{
    /// <summary>
    /// 最大最小距离算法（小中取大算法）
    /// </summary>
    public class SpaceCalculate
    {

        private List<Point> points;         // 要计算的点位
        private int N;                      // 点的个数
        private List<Point> clusterPoints;  // 聚类点集合
        private List<double> distance;      // 记录各个点到第一个聚类点的距离
        private double max1, max2;          // 用于取各个聚类点
        private int i, j, h, f = 1;         // f 聚类中心的个数
        private List<int> maxIndex;         // 用于记录聚类中心的索引
        private double[,] dd;               // 在循环体中记录各点和聚类中心的距离
        private double Q;                   // 最小值的阈值
        private double[,] w = new double[100, 4];    // 各个点到各个聚类中心的距离最小值和最大值：最大聚类中心索引、最大距离、最小聚类中心索引、最小距离
        private double max, min;            // 最大距离和最小距离

        private const double C = 0.5;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_points">初始化的点集</param>
        public SpaceCalculate(List<Point> _points)
        {
            this.points = _points;
            this.N = this.points.Count;
            clusterPoints = new List<Point>
            {
                // 假设第一个点位于第一个聚类中心
                this.points[0]
            };
            distance = new List<double>();
            maxIndex = new List<int> { 0 };
            max = min = 0;
        }

        /// <summary>
        /// 开始计算
        /// </summary>
        /// <returns></returns>
        public double StartCalc()
        {
            //points.Where(t => t.Latitude > 0);

            // 各点到聚类的距离
            DoToCluster();

            max1 = distance[0];
            for (j = 0; j < N; j++)
            {
                if (distance[j] > max1)
                {
                    max1 = distance[j];
                    maxIndex.Add(j);
                    clusterPoints.Add(points[j]);
                    f++;
                }
            }

            dd = new double[N, f];

            Q = C * max1;               // 阈值Q

            // 各点到各个聚类中心的距离，并求出最大和最小
            Center();
            // 点到聚类中心的最小值
            //Min();

            return max;
        }

        /// <summary>
        /// 各点到第一个聚类点的距离
        /// </summary>
        private void DoToCluster()
        {
            for (i = 0; i < N; i++)
            {
                distance.Add(GeoDistance.GetDistance(this.points[i], clusterPoints[0]));
            }
        }

        /// <summary>
        /// 各点到各个聚类中心的距离
        /// </summary>
        private void Center()
        {
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < f; j++)
                {
                    // 对于聚类点本身不做计算也不比较最大、最小值
                    if (i == maxIndex[j])
                    {
                        dd[i, j] = 0;
                    }
                    else
                    {
                        dd[i, j] = GeoDistance.GetDistance(points[i], clusterPoints[j]);
                        if (i == 1 && j == 0)
                        {
                            min = max = dd[i, j];
                        }
                        else
                        {
                            if (min > dd[i, j])
                            {
                                min = dd[i, j];
                            }
                            else if (max < dd[i, j])
                            {
                                max = dd[i, j];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 点到聚类中心距离的最小值
        /// </summary>
        private void Min()
        {
            for (i = 0; i < N; i++)
            {
                w[i, 0] = dd[i, 1];
                for (j = 1; j <= f; j++)
                {
                    if (w[i, 0] >= dd[i, j])
                    {
                        w[i, 0] = dd[i, j];
                        w[i, 2] = j;
                    }
                }
            }

            max2 = w[0, 0];
            for (i = 0; i < N; i++)
            {
                if (max2 < w[i, 0])
                {
                    max2 = w[i, 0];
                    h = i;
                }
            }

            if (max2 > Q)
            {
                f = f + 1;
                maxIndex.Add(h);
            }
            else
            {

            }
        }

    }
}
