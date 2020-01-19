using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPIMonitor.NETCore.MVCTest.Exception;

namespace WebAPIMonitor.NETCore.MVCTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        app.UseHsts();
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();
        //    app.UseCookiePolicy();

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        ////public void Configure(ApplicationBulider app, IHostingEnvironment env)
        //{
        //    app.Use(next =>
        //    {
        //        return async context =>
        //        {
        //            await context.Response.WriteAsync("<h1>I`m Middleware 1</h1>");
        //            await next(context);
        //        };
        //    }
        //    );

        //    app.Use(next =>
        //    {
        //        return async context =>
        //        {
        //            await context.Response.WriteAsync("<h1>I`m Middleware 2</h1>");
        //            //await next(context);
        //        };
        //    }
        //    );

        //    app.Use(next =>
        //    {
        //        return async context =>和你们
        //        {
        //            await context.Response.WriteAsync("<h1>I`m Middleware 3</h1>");
        //            await next(context);
        //        };
        //    }
        //    );
        //}
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    var start = DateTime.Now;       // 记录当前时间
                    await next.Invoke(context);
                    var ts = DateTime.Now - start;  // 记录之后中间件调用完成消耗的时间
                    await context.Response.WriteAsync($"<div class=\"alert alert-info\" rol=\"alert\">共耗时:{ts.TotalMilliseconds}毫秒！</div>");
                };
            }
            );

            // 两种不同的写法
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        Thread.Sleep(100);      // 强制等待
            //        await next(context);
            //    };
            //}
            //);
            app.Use((context, next) =>
            {
                Thread.Sleep(100);      // 强制等待
                return next();
            });
            app.Use(async (context, next) =>
            {
                await next();
                Thread.Sleep(100);      // 强制等待
            });

            // Run 方法是一个约定， 让一些中间件组件能暴露在管道末端运行的Run [Middleware]方法。
            // 添加这个后，后面的不能执行
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("End Width Run!");
            //});

            // 使用 Map，该扩展用作分支管道的约定
            app.Map("/map1", HandleMapTest1);
            app.Map("/map2", HandleMapTest2);
            // Map 嵌套
            app.Map("/level1", level1App =>
            {
                level1App.Map("/level2a", level2aAPP =>
                 {
                     level2aAPP.Run(async context =>
                     {
                         await context.Response.WriteAsync("Map level1-level2a");
                     });
                 });
                level1App.Map("/level2b", level2bApp =>
                 {
                     level2bApp.Run(async context =>
                     {
                         await context.Response.WriteAsync("Map level1-level2b");
                     });
                 });
            });
            // Map 一次匹配多个片段，这里有上面的运行的时候，这个会截断，（是因为路径第一级是一样的，修改这个第一级就可以了）
            app.Map("/level1/level2", level =>
            {
                level.Run(async context =>
                {
                    await context.Response.WriteAsync("Map level1/level2");
                });
            });

            // 自定义中间件的使用，并展示
            app.UseRequestCulture();
            app.Use(async (context, next) =>
            {
                await next();
                await context.Response.WriteAsync(
                    $"<div class=\"alert alert-info\" rol=\"alert\">{CultureInfo.CurrentCulture.DisplayName}</div>");
            });

            // MapWhen 使用，根据给定谓词的结果分支请求流水线
            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }
        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }
    }
}
