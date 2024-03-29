﻿using SMTPServer.Attributes;
using System;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        [SmtpCommandMethod("EHLO", 1)]
        [AllowConnectionState(ConnectionState.GreetingSent)]
        private void ReceiveEhloCommand(String message)
        {
            SendEhloReply();
        }
    }
}
