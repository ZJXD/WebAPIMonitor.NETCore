using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMonitor.NETCore.MVCTest
{
    public class ApplicationBulider : IApplicationBuilder
    {
        public IServiceProvider ApplicationServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFeatureCollection ServerFeatures => throw new NotImplementedException();

        public IDictionary<string, object> Properties => throw new NotImplementedException();

        public RequestDelegate Build()
        {
            // 没有任何中间操作返回状态码 404
            RequestDelegate app = context =>
            {
                context.Response.StatusCode = 404;
                return Task.FromResult(0);
            };

            // 为了保证中间件的顺序，需要 Reverse
            foreach (var componet in _components.Reverse())
            {
                // 把当前中间件的 app 作为 next 传入当前 componet
                // 返回的中间件存入 app ，然后作为 next 传入下一个 componet
                app = componet(app);
            }

            return app;
        }

        public IApplicationBuilder New()
        {
            throw new NotImplementedException();
        }

        // 用来存储注册的中间件列表
        private readonly IList<Func<RequestDelegate, RequestDelegate>> _components = new List<Func<RequestDelegate, RequestDelegate>>();

        // 使用USe方法注册中间件
        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }
    }
}
