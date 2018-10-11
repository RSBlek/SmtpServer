using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TCPServer;
using TCPServer.Models;

namespace SMTPServer
{
    public partial class SmtpServer : TcpServer
    {
        public SmtpServerConfiguration Configuration { get; private set; }

        private readonly SmtpConnectionHandler connectionHandler = new SmtpConnectionHandler();

        public new void Start()
        {
            base.ConnectionBacklog = Configuration.ConnectionBacklog;
            base.Start();
        }

        public SmtpServer(IPAddress ipAddress, int port, string name) : base(ipAddress, port)
        {
            this.Configuration = new SmtpServerConfiguration(this, ipAddress, port, name);
        }

        public override void OnConnectionClosed(TcpConnection tcpConnection, CloseReason closeReason)
        {
            Console.WriteLine("Disconnected: " + closeReason);
        }

        public override void OnConnectionEstablished(TcpConnection tcpConnection)
        {
            SmtpConnection smtpConnection = new SmtpConnection(tcpConnection, Configuration);
            connectionHandler.AddSmtpConnection(tcpConnection, smtpConnection);
            smtpConnection.SendGreetingReply();
        }

        public override void OnDataReceived(TcpConnection tcpConnection, byte[] data)
        {
            connectionHandler.GetSmtpConnection(tcpConnection).ReceiveData(data);
        }

    }
}
