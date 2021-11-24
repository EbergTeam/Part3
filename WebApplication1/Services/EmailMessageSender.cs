using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message send by Email";
        }
    }
}
