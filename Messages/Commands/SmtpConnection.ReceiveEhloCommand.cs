using SMTPServer.Attributes;
using System;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("EHLO", 0)]
        [AllowConnectionState(ConnectionState.Established)]
        private void ReceiveEhloCommand(String message)
        {
            int abc = 3;
        }
    }
}
