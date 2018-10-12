using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendCommandUnrecognizedReply()
        {
            SendMessage("500 Command not recognized");
        }
    }
}
