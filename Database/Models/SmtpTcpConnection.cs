using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace SMTPServer.Database.Models
{
    internal class SmtpTcpConnection
    {
        [Key]
        public Int64 ID { get; set; }

        [Column("IP")]
        [Required]
        [MinLength(4)]
        [MaxLength(16)]
        public byte[] IPBytes { get; private set; }

        [Required]
        public Int32 Port { get; set; }

        public SmtpServerInstance ServerInstance { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [NotMapped]
        public IPAddress IP
        {
            get { return new IPAddress(IPBytes); }
            set { IPBytes = value.GetAddressBytes(); }
        }
    }
}
