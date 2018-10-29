using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FileManager;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.Extensions.Primitives;
using Util.GeoTool;

namespace WebAPIMonitor.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Console.Read();

            #region 输出目录结构

            //IServiceCollection services = new ServiceCollection();
            //services.AddSingleton<IFileProvider>(new PhysicalFileProvider(@"C:\DIT.PROD.WGH.BacklogNumberService.Log"))
            //.AddSingleton<IFileManager, FileManager.FileManager>()
            //.BuildServiceProvider()
            //.GetService<IFileManager>()
            //.ShowStructure((layer, name) => Console.WriteLine("{0}{1}", new string('\t', layer), name));

            //Console.Read();
            #endregion

            #region 读取文件内容
            //     string content = new ServiceCollection()
            //.AddSingleton<IFileProvider>(new PhysicalFileProvider(@"C:\dit.prod.wgh.log\2018-08-27"))
            //.AddSingleton<IFileManager, FileManager.FileManager>()
            //.BuildServiceProvider()
            //.GetService<IFileManager>()
            //.ReadAllTextAsync("Error.txt").Result;

            //     Debug.Assert(content == File.ReadAllText(@"C:\dit.prod.wgh.log\2018-08-27\Error.txt"));
            #endregion

            #region 监控文件

            //IFileProvider fileProvider = new PhysicalFileProvider(@"D:\test");
            //ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), () => LoadFileAsync(fileProvider));
            //while (true)
            //{
            //    File.WriteAllText(@"D:\test\data.txt", DateTime.Now.ToString());
            //    Task.Delay(50000).Wait();
            //}
            #endregion

            #region 测试 Geohash

            double lat = 30.2719106;
            double lon = 120.1652627; //需要查询经纬度，目前指向的是BeiJing
            string hash = GeohashHelper.Encode(lat, lon);
            int geohashLen = 8;
            /*获取中心点的geohash*/
            String geohash = hash.Substring(0, geohashLen);
            /*获取所有的矩形geohash， 一共是九个 ，包含中心点,打印顺序请参考参数*/
            String[] result = GeohashHelper.getGeoHashExpand(geohash);
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

        public static async void LoadFileAsync(IFileProvider fileProvider)
        {
            Stream stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
            {
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer));
            }
        }
    }
}
