using SMTPServer.Attributes;
using System;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("HELO", 1)]
        [AllowConnectionState(ConnectionState.GreetingSent)]
        private void ReceiveHeloCommand(String message)
        {
            SendHeloReply();
        }
    }
}
