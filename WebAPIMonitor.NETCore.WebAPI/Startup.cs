﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPIMonitor.NETCore.Models;
using Microsoft.EntityFrameworkCore;
using WebAPIMonitor.NETCore.WebAPI.Hubs;

namespace WebAPIMonitor.NETCore.WebAPI
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
            // 配置跨域处理(1)
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader()
                 //.WithOrigins("http: //localhost: 55830")  // 配置指定的来源，可以从配置文件中读取
                 .AllowAnyOrigin()  // 允许所有来源的主机访问
                 .AllowCredentials();   // 允许处理 cookie
            }));
            // 配置跨域处理(2)
            //services.AddCors();

            services.AddDbContext<TodoContext>(opt =>
            opt.UseInMemoryDatabase("TodoList"));

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
                .AddJsonOptions(json =>
                {
                    // 返回数据中时间数据格式化
                    json.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // 使用跨域(1)，也可以在 controller 中配置 [EnableCors("CorsPolicy")]
            app.UseCors("CorsPolicy");
            // 使用跨域(2)
            //app.UseCors(builder => builder
            //.AllowAnyOrigin()
            //.AllowAnyHeader()
            //.AllowAnyMethod()
            //.AllowCredentials());

            // 配置项目提供静态文件并启用默认文件映射
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "DefaultApi",
                    template: "api/{controller}/{id}"
                //defaults: new { id = RouteParameter.Optional }
                );
            });
        }
    }
}