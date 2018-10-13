using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendEhloReply()
        {
            for (int i = 0; i < ServerConfiguration.Extensions.Count; i++)
                SendMessage("250-" + ServerConfiguration.Extensions[i]);
            SendMessage("250 OK");
            ConnectionState = ConnectionState.Initial;
        }
    }
}
