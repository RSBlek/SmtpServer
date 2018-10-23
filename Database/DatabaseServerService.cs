using Microsoft.EntityFrameworkCore;
using SMTPServer.Database.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace SMTPServer.Database
{
    internal class DatabaseServerService
    {
        private SmtpServerInstance smtpServerInstance;

        public void CreateDatabase()
        {
            using (SmtpContext smtpContext = new SmtpContext())
            {
                if (smtpContext.Database.EnsureCreated())
                    Logger.Log("Database created");
                else
                    Logger.Log("Database already exists");
            }
        }

        public SmtpServerInstance GetSmtpServerInstance()
        {
            return smtpServerInstance;
        }

        public void AddSmtpServerInstance(String hostName, IPAddress ipAddress, int port, DateTime timestamp)
        {
            using (SmtpContext smtpContext = new SmtpContext())
            {
                SmtpServerInstance smtpServerInstance = new SmtpServerInstance()
                {
                    HostName = hostName,
                    IP = ipAddress,
                    Port = port,
                    Timestamp = timestamp,
                };
                smtpContext.SmtpServerInstances.Add(smtpServerInstance);
                this.smtpServerInstance = smtpServerInstance;
                smtpContext.SaveChanges();
            }
        }

        public void AddSmtpTcpConnection(IPAddress ipAddress, int port, DateTime timestamp)
        {
            using (SmtpContext smtpContext = new SmtpContext())
            {
                SmtpServerInstance attachedServerInstance = null;
                if (smtpServerInstance != null)
                    attachedServerInstance = smtpContext.SmtpServerInstances.Where(x => x.ID == smtpServerInstance.ID).First();
                smtpContext.SmtpTcpConnections.Add(new SmtpTcpConnection()
                {
                    IP = ipAddress,
                    Port = port,
                    ServerInstance = attachedServerInstance,
                    Timestamp = timestamp
                });
                smtpContext.SaveChanges();
            }
        }
    }
}
