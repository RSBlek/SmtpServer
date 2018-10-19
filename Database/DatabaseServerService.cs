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

        public void AddSmtpServerInstance(DateTime timestamp, String hostName, IPAddress ipAddress, int port)
        {
            using(SmtpContext smtpContext = new SmtpContext())
            {
                smtpContext.SmtpServerInstances.Add(new SmtpServerInstance()
                {
                    Timestamp = timestamp,
                    HostName = hostName,
                    IP = ipAddress.ToString(),
                    Port = port
                });
                smtpContext.SaveChanges();
            }
        }
    }
}
