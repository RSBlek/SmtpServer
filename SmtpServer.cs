using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TCPServer;
using TCPServer.Models;
using SMTPServer.Database;
using Microsoft.EntityFrameworkCore;

namespace SMTPServer
{
    public partial class SmtpServer : TcpServer
    {
        public SmtpServerConfiguration Configuration { get; private set; }

        private readonly SmtpConnectionHandler connectionHandler = new SmtpConnectionHandler();
        private readonly SmtpCommandHandler commandHandler = new SmtpCommandHandler();
        private readonly DatabaseServerService db = new DatabaseServerService();

        public new void Start()
        {
            base.ConnectionBacklog = Configuration.ConnectionBacklog;
            commandHandler.Initialize();
            db.CreateDatabase();
            base.Start();
            db.AddSmtpServerInstance(DateTime.Now, Configuration.Name, Configuration.IPAddress, Configuration.Port);
            Logger.Log($"SMTP Server {Configuration.Name} started on {Configuration.IPAddress}:{Configuration.Port}");
        }

        public SmtpServer(IPAddress ipAddress, int port, string name) : base(ipAddress, port)
        {
            Configuration = new SmtpServerConfiguration(this, ipAddress, port, name);
        }

        public override void OnConnectionClosed(TcpConnection tcpConnection, CloseReason closeReason)
        {
            connectionHandler.RemoveSmtpConnection(tcpConnection);
            Logger.Log("Disconnected");
        }

        public override void OnConnectionEstablished(TcpConnection tcpConnection)
        {
            SmtpConnection smtpConnection = new SmtpConnection(tcpConnection, Configuration, commandHandler);
            connectionHandler.AddSmtpConnection(tcpConnection, smtpConnection);
            smtpConnection.SendGreetingReply();
        }

        public override void OnDataReceived(TcpConnection tcpConnection, byte[] data)
        {
            connectionHandler.GetSmtpConnection(tcpConnection).ReceiveData(data);
        }

    }
}
