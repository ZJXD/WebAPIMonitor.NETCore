using System;
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
using System.Reflection;
using DataBase.MySQL;
using System.IO;

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

            //services.AddDbContext<LogContext>(opt => opt.UseMySQL(Configuration.GetConnectionString("LogContext")));
            //services.Add(new ServiceDescriptor(typeof(LogContext), new LogContext(Configuration.GetConnectionString("LogContext"))));

            //services.Add(new ServiceDescriptor(typeof(MySQLDatabase), new MySQLDatabase(Configuration.GetConnectionString("LogContext"))));
            services.AddScoped(_ => new MySQLDatabase(Configuration.GetConnectionString("LogContext")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            // 注册 Swagger 生成器，定义一个或多个文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                    Title = "My API",
                    Version = "v1",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //集中注册服务
            Dictionary<Type, Type[]> classNames = GetClassName(new string[] { "WebAPIMonitor.NETCore.BLL" });
            foreach (var item in classNames)
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
                .AddJsonOptions(json =>
                {
                    // 返回数据中时间数据格式化
                    json.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            // 添加到依赖关系注入系统
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

            // 添加到中间件管道
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // 启用中间件将生产的 Swagger 作为 JSON 端点提供服务
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            // 启动中间件以提供 Swagger-ui，并指定 json端点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My API v1");
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

        /// <summary>  
        /// 获取程序集中的实现类对应的多个接口
        /// </summary>  
        /// <param name="assemblyNames">程序集</param>
        public Dictionary<Type, Type[]> GetClassName(string[] assemblyNames)
        {
            var result = new Dictionary<Type, Type[]>();

            for (int i = 0; i < assemblyNames.Length; i++)
            {
                string assemblyName = assemblyNames[i];
                if (!string.IsNullOrEmpty(assemblyName))
                {
                    Assembly assembly = Assembly.Load(assemblyName);
                    List<Type> ts = assembly.GetTypes().ToList();

                    foreach (var item in ts.Where(s => !s.IsInterface))
                    {
                        var interfaceType = item.GetInterfaces();
                        result.Add(item, interfaceType);
                    }
                }
            }
            return result;
        }
    }
}
