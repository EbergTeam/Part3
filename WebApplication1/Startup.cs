using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles(); // отправка статических веб-страниц по умолчанию без обращения к ним по полному пути
                                   // в этом случае при отправке запроса к корню веб-приложения типа http://localhost:xxxx/
                                   // приложение будет искать в папке wwwroot следующие файлы default.html, index.html
            app.UseStaticFiles();  // чтобы приложение могло бы отдавать статические файлы клиенту

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("It work!!!");
            });
        }
    }
}
