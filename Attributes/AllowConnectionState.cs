using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true) ]
    internal class AllowConnectionState : Attribute
    {
        public ConnectionState ConnectionState { get; }
        public AllowConnectionState(ConnectionState connectionState)
        {
            this.ConnectionState = connectionState;
        }
    }
}
