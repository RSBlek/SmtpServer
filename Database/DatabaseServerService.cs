using Microsoft.EntityFrameworkCore;
using SMTPServer.Database.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SMTPServer.Database
{
    internal class DatabaseServerService
    {
        public void CreateDatabase()
        {
            using(SmtpContext smtpContext = new SmtpContext())
            {
                if (smtpContext.Database.EnsureCreated())
                    Logger.Log("Database created");
                else
                    Logger.Log("Database already exists");
            }
        }

        public void AddSmtpServerInstance(String hostName, IPAddress ipAddress, int port, DateTime timestamp)
        {
            using(SmtpContext smtpContext = new SmtpContext())
            {
                smtpContext.SmtpServerInstances.Add(new SmtpServerInstance()
                {
                    HostName = hostName,
                    IP = ipAddress.ToString(),
                    Port = port,
                    Timestamp = timestamp,
                });
                smtpContext.SaveChanges();
            }
        }

        public void AddSmtpTcpConnection(IPAddress ipAddress, int port, DateTime timestamp)
        {
            using (SmtpContext smtpContext = new SmtpContext())
            {
                smtpContext.SmtpTcpConnections.Add(new SmtpTcpConnection()
                {
                    IP = ipAddress.ToString(),
                    Port = port,
                    Timestamp = timestamp
                });
                smtpContext.SaveChanges();
            }
        }
    }
}
