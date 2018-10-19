using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SMTPServer.Database.Models;
using System.Reflection;
using System.IO;

namespace SMTPServer.Database
{
    class SmtpContext : DbContext
    {
        internal DbSet<SmtpServerInstance> SmtpServerInstances { get; set; }
        internal DbSet<SmtpTcpConnection> SmtpTcpConnections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SmtpDatabase.db");
        }
    }
}
