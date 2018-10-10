using System;
using Topshelf;

namespace WebAPIMonitor.NETCore.TopshelfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Host host = HostFactory.New(x =>
            {
                x.RunAsLocalSystem();
                x.SetServiceName("WebAPIMonitor.NETCore.TopshelfTest");
                x.SetDisplayName("WebAPIMonitor.NETCore.TopshelfTest");
                x.SetDescription("测试 .NET Core 下 Topshelf");
                x.StartAutomatically();
                x.EnableShutdown();

                x.Service<WriteLogService>(hostSettings => new WriteLogService());

                // 设置服务失败后的操作，分别对应第一次、第二次、后续
                x.EnableServiceRecovery(t =>
                {
                    t.RestartService(0);

                    t.RestartService(0);

                    t.RestartService(0);
                    t.OnCrashOnly();
                });
            });

            host.Run();
        }
    }
}
