using SMTPServer.Attributes;
using System;
using TCPServer.Models;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("QUIT", 0)]
        [AllowEveryConnectionState]
        private void ReceiveQuitCommand(String message)
        {
            ConnectionState = ConnectionState.ReceivingMailData;
            tcpConnection.CloseConnection(CloseReason.ClosedByClient);
        }
    }
}
