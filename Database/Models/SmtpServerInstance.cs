using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMTPServer.Database.Models
{
    internal class SmtpServerInstance
    {
        [Key]
        public Int64 ID { get; set; }
        [Required]
        public String HostName { get; set; }
        [Required]
        public String IP { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
