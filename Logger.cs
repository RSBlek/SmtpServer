using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
    }

    internal class Logger
    {
        public static void Log(String message)
        {
            Log(message, LogLevel.Info);
        }

        public static void Log(String message, LogLevel logLevel)
        {
            Console.WriteLine("["+ DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] " + message);
        }
    }
}
