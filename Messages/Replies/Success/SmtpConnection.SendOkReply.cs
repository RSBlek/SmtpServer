using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendOkReply()
        {
            SendMessage("250 OK");
        }
    }
}
