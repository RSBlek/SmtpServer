using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer
{
    public enum ConnectionState
    {
        Closed,
        Established,
        GreetingSent,
        Initial,
        MailTransactionStarted,
        ReceivingMailData,
        ReadyForData,
    }
}
