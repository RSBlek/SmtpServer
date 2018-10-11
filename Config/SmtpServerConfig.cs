using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SMTPServer
{
    public class SmtpServerConfiguration
    {
        public IPAddress IPAddress { get => smtpServer._ipAddress; private set => smtpServer._ipAddress = value; }
        public int Port { get => smtpServer._port; private set => smtpServer._port = value; }
        public int ConnectionBacklog { get => smtpServer._connectionBacklog; set => smtpServer._connectionBacklog = value; }
        public String Name { get => smtpServer._name; private set => smtpServer._name = value; }

        private readonly SmtpServer smtpServer;

        public SmtpServerConfiguration(SmtpServer smtpServer, IPAddress ipAddress, int port, string name)
        {
            this.smtpServer = smtpServer;
            this.IPAddress = ipAddress;
            this.Port = port;
            this.Name = name;
        }

    }
}
