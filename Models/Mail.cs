using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;

namespace SMTPServer
{
    public class Mail
    {
        public String Sender { get; set; }
        public List<String> Recipients { get; } = new List<String>();
        public MimeMessage MimeMessage { get; private set; }

        public void SetMessage(byte[] inputData)
        {
            MemoryStream memoryStream = new MemoryStream(inputData);
            MimeMessage mimeMessage = MimeMessage.Load(memoryStream);
            this.MimeMessage = mimeMessage;
        }

        public void Clear()
        {
            this.MimeMessage = null;
            Sender = null;
            Recipients.Clear();
        }
    }
}
