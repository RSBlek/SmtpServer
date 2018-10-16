using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendStartMailInputReply()
        {
            SendMessage("354 Start mail input; end with <CRLF>.<CRLF>");
        }
    }
}
