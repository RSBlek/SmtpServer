using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal void SendParameterSyntaxErrorReply()
        {
            SendMessage("501 Syntax error in parameters or arguments");
        }
    }
}
