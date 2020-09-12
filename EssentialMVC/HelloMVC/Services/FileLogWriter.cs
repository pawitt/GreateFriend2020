using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Services
{
    public class FileLogWriter : ILogWriter
    {
        public string Name => "FileLogWriter";

        public void write(string s)
        {
            s += "\n";
            System.IO.File.AppendAllText("log.txt", s);
        }
    }
}
