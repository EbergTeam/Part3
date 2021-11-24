using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1
{
    public class MessageService
    {
        IMessageSender messageSender;
        public MessageService(IMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }
        public string Send()
        {
            return messageSender.Send();
        }

    }
}
