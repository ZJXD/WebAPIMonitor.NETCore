using System;
using System.Collections.Generic;
using System.Text;

namespace Util.GeoTool
{
    public class GeoDistance
    {
        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="startPoint">开始点位</param>
        /// <param name="endPoint">开始点位</param>
        /// <returns></returns>
        public static double GetDistance(Point startPoint, Point endPoint)
        {
            double radLat1 = Rad(startPoint.Latitude);
            double radLng1 = Rad(startPoint.Longitude);
            double radLat2 = Rad(endPoint.Latitude);
            double radLng2 = Rad(endPoint.Longitude);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }
    }
}
