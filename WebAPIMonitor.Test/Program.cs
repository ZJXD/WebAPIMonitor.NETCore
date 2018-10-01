using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FileManager;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.Extensions.Primitives;

namespace WebAPIMonitor.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Console.Read();

            // 输出目录结构

            //IServiceCollection services = new ServiceCollection();
            //services.AddSingleton<IFileProvider>(new PhysicalFileProvider(@"C:\DIT.PROD.WGH.BacklogNumberService.Log"))
            //.AddSingleton<IFileManager, FileManager.FileManager>()
            //.BuildServiceProvider()
            //.GetService<IFileManager>()
            //.ShowStructure((layer, name) => Console.WriteLine("{0}{1}", new string('\t', layer), name));

            //Console.Read();

            // 读取文件内容
            //     string content = new ServiceCollection()
            //.AddSingleton<IFileProvider>(new PhysicalFileProvider(@"C:\dit.prod.wgh.log\2018-08-27"))
            //.AddSingleton<IFileManager, FileManager.FileManager>()
            //.BuildServiceProvider()
            //.GetService<IFileManager>()
            //.ReadAllTextAsync("Error.txt").Result;

            //     Debug.Assert(content == File.ReadAllText(@"C:\dit.prod.wgh.log\2018-08-27\Error.txt"));

            // 监控文件
            IFileProvider fileProvider = new PhysicalFileProvider(@"D:\test");
            ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), () => LoadFileAsync(fileProvider));
            while (true)
            {
                File.WriteAllText(@"D:\test\data.txt", DateTime.Now.ToString());
                Task.Delay(50000).Wait();
            }
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
