using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendLineTooLongReply()
        {
            SendMessage("500 Line too long");
        }
    }
}
