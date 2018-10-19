using System;
using System.Collections.Generic;
using System.IO;

namespace SMTPServer
{
    public class Mail
    {
        public String Sender { get; set; }
        public List<String> Recipients { get; } = new List<String>();
        public byte[] Data { get; private set; }

        public void SetData(byte[] data)
        {
            this.Data = data;
        }

        public void Clear()
        {
            Data = null;
            Sender = null;
            Recipients.Clear();
        }
    }
}
