using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class TimeService
    {
        public string Time { get; set; }
        public TimeService()
        {
            Time = System.DateTime.Now.ToString();
        }      
        public string GetTime() => System.DateTime.Now.ToString();
    }
}
