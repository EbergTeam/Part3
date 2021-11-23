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
        // ��������� �������� �������� ������� IApplicationBuilder �� �������� ���������. ���������� ��������� - middleware
        // ��� ������������ ��������� ��������� ������� ����������� ������ Run, Map � Use
        public void Configure(IApplicationBuilder app)
        {
            // USE - ���������� ���������� middleware � ��������, ������������ ��� ��������� �����
            // ����� �������� ���������� ����. ���������� ����� await next.Invoke(), �� ����� ���������� ��� ����� await next.Invoke()
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("USE BEFORE Invoke() \n");
                await next.Invoke();
                await context.Response.WriteAsync("\nUSE AFTER Invoke()");
            });

            // MAP ����������� ���� �������. ���� ������ ���� //localhost:44322/about/, �� ����������� ����� About
            app.Map("/about", About);
            // MapWhen(true/false, About); ���� ������� �������, �� �������� ����� About()
            
            // ��������� ������ MAP - ����������� ���� �������. � ����������� �� ���� �������� ������...
            app.Map("/index", (appBuilder) =>
            {
                // ..�����
                appBuilder.Map("/help", Help);

                //  ..��������� �����
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("INDEX");
                });
            });

            // RUN - ���������� ���������� middleware � ��������, ������������ ��� ��������� �����
            // �� �������� ������� ������ ���������� � ������ ��������� ������� �� �������� (�������� ������������)
            app.Run(async (context) =>
            {
                var host = context.Request.Host.Value;
                var path = context.Request.Path;
                var query = context.Request.QueryString.Value;
                await context.Response.WriteAsync("RUN host=" + host + ", path " + path + ", query" + query);              
            });
        }

        private static void About(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async (context) =>
            {
                await context.Response.WriteAsync("ABOUT");
            });
        }

        private static void Help(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async (context) =>
            {
                await context.Response.WriteAsync("HELP");
            });
        }
    }
}
