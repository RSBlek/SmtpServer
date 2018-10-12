using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer.Attributes
{
    internal class AllowConnectionState : Attribute
    {
        public ConnectionState ConnectionState { get; }
        public AllowConnectionState(ConnectionState connectionState)
        {
            this.ConnectionState = connectionState;
        }
    }
}
