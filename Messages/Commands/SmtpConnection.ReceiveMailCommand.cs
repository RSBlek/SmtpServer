using SMTPServer.Attributes;
using System;
using System.Text.RegularExpressions;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("MAIL", 1)]
        [AllowConnectionState(ConnectionState.Initial)]
        [AllowConnectionState(ConnectionState.MailTransactionStarted)]
        [AllowConnectionState(ConnectionState.ReceivingMailData)]
        [AllowConnectionState(ConnectionState.ReadyForData)]
        private void ReceiveMailCommand(String message)
        {
            mail.Clear();
            Regex regex = new Regex(@"(?<=from:<)(.*?)(?=>)", RegexOptions.IgnoreCase);
            Match match = regex.Match(message);
            if (match.Success)
            {
                mail.Sender = match.Value;
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
