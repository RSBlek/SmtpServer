using SMTPServer.Attributes;
using System;
using System.Text.RegularExpressions;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("MAIL", 1)]
        [AllowConnectionState(ConnectionState.Initial)]
        private void ReceiveMailCommand(String message)
        {
            mailBuffer.Clear();
            String[] messageParts = message.Split(' ');
            Regex regex = new Regex(@"<.*>");
            Match match = regex.Match(messageParts[0]);
            if (!match.Success)
            {
                mailBuffer.Sender = match.Value;
                this.ConnectionState = ConnectionState.MailTransactionStarted;
                SendOkReply();
            }
            else
            {
                SendParameterSyntaxErrorReply();
            }


        }
    }
}
