using System;
using System.Collections.Concurrent;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal class SmtpConnectionHandler
    {
        private ConcurrentDictionary<TcpConnection, SmtpConnection> smtpConnections = new ConcurrentDictionary<TcpConnection, SmtpConnection>();

        internal void AddSmtpConnection(TcpConnection tcpConnection, SmtpConnection smtpConnection)
        {
            smtpConnections.TryAdd(tcpConnection, smtpConnection);
        }

        internal SmtpConnection GetSmtpConnection(TcpConnection tcpConnection)
        {
            return smtpConnections[tcpConnection];
        }

        internal SmtpConnection RemoveSmtpConnection(TcpConnection tcpConnection)
        {
            SmtpConnection output;
            smtpConnections.TryRemove(tcpConnection, out output);
            return output;
        }

    }
}
