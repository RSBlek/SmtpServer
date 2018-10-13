using SMTPServer.Attributes;
using System;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("NOOP", 0)]
        [AllowEveryConnectionState]
        private void ReceiveNoopCommand(String message)
        {
            SendOkReply();
        }
    }
}
