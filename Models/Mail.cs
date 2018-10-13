using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPServer
{
    public class Mail
    {
        public String Sender { get; set; }
        public List<String> Recipients { get; } = new List<String>();

        public void Clear()
        {
            Sender = null;
            Recipients.Clear();
        }
    }
}
