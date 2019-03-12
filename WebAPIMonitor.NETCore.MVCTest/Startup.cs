using System;
using System.Collections.Generic;
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
        //        return async context =>
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

            app.Use(next =>
            {
                return async context =>
                {
                    Thread.Sleep(100);      // 强制等待
                    await next(context);
                };
            }
            );

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
