using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Services
{
    public class LineLogWriter : ILogWriter
    {
        public string Name => "Line Notify";

        // XML comment
        /// <summary>
        /// ส่งไลน์
        /// </summary>
        /// <param name="s"></param>
        public void write(string s)
        {
            //--https://notify-bot.line.me/th/
            //--dotnet
            var noti = new Notifier("tB8cHTDmYHCF6SOZ0Yl4nANViFJxdVmof6R9zufWLAG");
            noti.Notify(s).GetAwaiter().GetResult();

            
        }
    }
}
