using System;
using System.Collections.Generic;
using System.Reflection;

namespace SMTPServer
{
    internal class SmtpCommand
    {
        public String Name { get; }
        public Int32 MinimumParameterCount { get; }
        public MethodInfo Method { get; }
        public List<ConnectionState> AllowedConnectionStates { get; } = new List<ConnectionState>();

        public SmtpCommand(string name, Int32 minimumParameterCount, MethodInfo methodInfo)
        {
            this.Name = name.ToUpper();
            this.MinimumParameterCount = minimumParameterCount;
            this.Method = methodInfo;
        }

    }
}
