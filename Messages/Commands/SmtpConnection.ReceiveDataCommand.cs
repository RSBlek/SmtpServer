using SMTPServer.Attributes;
using System;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("DATA", 0)]
        [AllowConnectionState(ConnectionState.ReadyForData)]
        private void ReceiveDataCommand(String message)
        {
            ConnectionState = ConnectionState.ReceivingMailData;
            SendStartMailInputReply();
        }
    }
}
