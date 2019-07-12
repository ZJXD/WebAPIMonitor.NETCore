using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Util.GeoTool;
using System.Collections.Generic;
using TinyCsvParser;
using ReadCSV;
using System.Linq;
using DataBase.MySQL;

namespace WebAPIMonitor.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Console.Read();

            #region 测试 Geohash

            //double lat = 30.2719106;
            //double lon = 120.1652627; //需要查询经纬度，目前指向的是BeiJing
            //string hash = GeohashHelper.Encode(lat, lon);
            //int geohashLen = 8;
            ///*获取中心点的geohash*/
            //String geohash = hash.Substring(0, geohashLen);
            ///*获取所有的矩形geohash， 一共是九个 ，包含中心点,打印顺序请参考参数*/
            //String[] result = GeohashHelper.getGeoHashExpand(geohash);
            #endregion

            #region 求一组点的最大距离和最小距离

            //List<Point> exportPoints = new List<Point>
            //{
            //    new Point { Latitude = 30.2702291, Longitude = 120.1754093 },
            //    new Point { Latitude = 30.3061665, Longitude = 120.1855999 },
            //    new Point { Latitude = 30.3045579, Longitude = 120.182148 },
            //    new Point { Latitude = 30.2980457, Longitude = 120.1750771 },
            //    new Point { Latitude = 30.2966139, Longitude = 120.1749036 },
            //    new Point { Latitude = 30.2987195, Longitude = 120.1633868 },
            //    new Point { Latitude = 30.3006863, Longitude = 120.204085 },
            //    new Point { Latitude = 30.2868773, Longitude = 120.1758432 }
            //    new Point { Latitude = 30.2702291, Longitude = 120.1754093 },
            //    new Point { Latitude = 30.2702291, Longitude = 120.1754093 }
            //};

            //SpaceCalculate spaceCalculate = new SpaceCalculate(exportPoints);
            //spaceCalculate.StartCalc();

            #endregion

            #region 聚类分析

            //ClusterAnalysis clusterAnalysis = new ClusterAnalysis(exportPoints, 2000);
            //clusterAnalysis.StartAnalysis();

            #endregion

            #region 读取 POI CSV文件
            StartRead();
            #endregion
        }

        //public void ConfigureServices(IServiceCollection ServiceCollection)
        //{
        //    ServiceCollection.AddSingleton<Microsoft.AspNetCore.Mvc.Filters.IFilterProvider>(new PhysicalFileProvider(@"c:\test"))
        //    .AddSingleton<IFileManager, FileManager.FileManager>()
        //    .BuildServiceProvider()
        //    .GetService<IFileManager>()
        //    .ShowStructure((layer, name) => Console.WriteLine("{0}{1}", new string('\t', layer), name));
        //}


        /// <summary>
        /// 开始读取CSV文件
        /// </summary>
        /// <param name="fileName"></param>
        private static void StartRead(string fileName = @"D:\WorkMark\地图数据\WeiboDataShare-master\anhui.csv")
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvPOIInfoMapping csvMapping = new CsvPOIInfoMapping();
            CsvParser<POIInfo> csvParser = new CsvParser<POIInfo>(csvParserOptions, csvMapping);

            var pOIInfos = csvParser.ReadFromFile(fileName, Encoding.UTF8).ToList();

            MySQLDatabase mySQLDatabase = new MySQLDatabase("server=localhost;port=3306;database=mytestdb;uid=root;password=erb356wer;SslMode=None");

            int count = 0;
            string InsertSQL = "";
            foreach (var item in pOIInfos)
            {
                if (item.Result != null)
                {
                    try
                    {
                        string sql = $"INSERT INTO poi_info(poi_id,name,address,longitude,latitude,point,city_code,type,field_1,field_2) " +
                            $"VALUES('{item.Result.Id}','{item.Result.Name}','{item.Result.Address}',{item.Result.Longitude}," +
                            $"{item.Result.Latitude},ST_GeomFromText('POINT({item.Result.Longitude} {item.Result.Latitude})'),'{item.Result.CityCode}'," +
                            $"'{item.Result.Type}',{item.Result.Filed1},{item.Result.Filed2});";
                        InsertSQL += sql;
                        count++;
                        if (count >= 5000)
                        {
                            mySQLDatabase.ExecuteBySql(InsertSQL);
                            InsertSQL = "";
                            count = 0;
                        }
                    }
                    catch (Exception)
                    {
                        InsertSQL = "";
                        count = 0;
                    }
                }
            }
        }
    }
}
