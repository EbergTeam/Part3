using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1
{
    public class SendMessageMiddleware
    {
        RequestDelegate next;
        TimeService _ts;

        // передача сервиса через конструктор middleware больше подходит для сервисов с жизненным циклом Singleton
        // которые создаются один раз для всех последующих запросов
        public SendMessageMiddleware(RequestDelegate next, TimeService ts)
        {
            this.next = next;
            _ts = ts;
        }

        // если же в middleware необходимо использовать сервисы с жизненным циклом Scoped или Transient
        // то лучше их передавать через параметр метода Invoke/InvokeAsync
        public async Task InvokeAsync(HttpContext context, TimeService ts)
        {
            await context.Response.WriteAsync("1. It work!!! Message send by Pigeon " + ts.Time + "    " + _ts.Time + "\n");
            await next.Invoke(context);
        }
    }
}
