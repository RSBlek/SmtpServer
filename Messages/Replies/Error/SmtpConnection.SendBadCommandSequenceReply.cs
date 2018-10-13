using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendBadCommandSequenceReply()
        {
            SendMessage("503 Bad sequence of commands");
        }
    }
}
