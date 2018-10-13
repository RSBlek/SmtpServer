using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    public partial class SmtpServer : TcpServer
    {
        internal IPAddress _ipAddress;
        internal int _port;
        internal int _connectionBacklog = 25;
        internal string _name;
        internal int _maximumLineLength = Int32.MaxValue;
        internal readonly List<String> _extensions = new List<string>()
        {
            "8BITMIME",
        };

    }
}
