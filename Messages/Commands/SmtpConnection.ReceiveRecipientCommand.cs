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
            Regex regex = new Regex(@"(?<=from:<)(.*?)(?=>)", RegexOptions.IgnoreCase);
            Match match = regex.Match(message);
            if (!match.Success)
            {
                mailBuffer.Recipients.Add(match.Value);
                ConnectionState = ConnectionState.ReadyForData;
                SendOkReply();
            }
            else
            {
                SendParameterSyntaxErrorReply();
            }
        }
    }
}
