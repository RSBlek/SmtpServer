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
            this.SendMessage("220 " + ServerConfiguration.Name + " service ready");
        }
    }
}
