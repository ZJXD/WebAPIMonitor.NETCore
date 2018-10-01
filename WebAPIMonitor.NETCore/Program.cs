namespace WebAPIMonitor.NETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()     // 注册启动类
                                           //.UseUrls("http://localhost:8000/", "http://localhost:9000") // 指定监听地址
                .Build();
    }
}
