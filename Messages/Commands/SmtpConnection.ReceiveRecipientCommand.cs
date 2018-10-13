using SMTPServer.Attributes;
using System;
using System.Text.RegularExpressions;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("RCPT TO:", 1)]
        [AllowConnectionState(ConnectionState.MailTransactionStarted)]
        private void RecieveRecipientCommand(String message)
        {
            String[] messageParts = message.Split(' ');
            Regex regex = new Regex("<.*>");
            Match match = regex.Match(messageParts[1]);
            if (!match.Success)
            {
                mailBuffer.Recipients.Add(match.Value);
                SendOkReply();
            }
            else
            {
                SendParameterSyntaxErrorReply();
            }
        }
    }
}
