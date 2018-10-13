using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendGreetingReply()
        {
            SendMessage("220 " + serverConfiguration.Name + " service ready");
            ConnectionState = ConnectionState.GreetingSent;
        }
    }
}
