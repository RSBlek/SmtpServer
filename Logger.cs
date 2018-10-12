using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer
{
    internal class Logger
    {
        public static void Log(String message)
        {
            Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " " + message);
        }
    }
}
