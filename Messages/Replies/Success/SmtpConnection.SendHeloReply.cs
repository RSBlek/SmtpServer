using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendHeloReply()
        {
            SendMessage("250 " + ServerConfiguration.Name);
            ConnectionState = ConnectionState.Initial;
        }
    }
}
