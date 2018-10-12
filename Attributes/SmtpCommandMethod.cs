using System;

namespace SMTPServer.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class SmtpCommandMethod : Attribute
    {
        public String Command { get; }
        public int MinimumParameterCount { get; }
        public SmtpCommandMethod(String command, int minimumParameterCount)
        {
            this.Command = command;
            this.MinimumParameterCount = minimumParameterCount;
        }

        public SmtpCommandMethod(String command)
        {
            this.Command = command;
            this.MinimumParameterCount = 0;
        }
    }
}
