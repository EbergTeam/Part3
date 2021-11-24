using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SmsMessageSender>();
            services.AddTransient<MessageService>();
            // extension method for IServiceCollection
            services.AddTimeService();
        }
        
        public void Configure(IApplicationBuilder app, IMessageSender ims, TimeService ts, MessageService ms) 
        {
            // 1. Add service to the parametr of the Invoke method of the middleware component
            app.UseMiddleware<SendMessageMiddleware>();

            // 2. Add service to the constructor of the class (except Startup)
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("2. It work!!! " + ms.Send() + "\n");
                await next.Invoke();
            });

            // 3.Add service to the parametr of the Configure method of the Startup class
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("3. It work!!! " + ims.Send() + ". Time: " + ts.GetTime());
            });
            
        }
    }
}
