using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        internal SmtpServerConfiguration ServerConfiguration { get => serverConfiguration; }

        private readonly TcpConnection tcpConnection;
        private readonly List<byte> dataBuffer = new List<byte>();
        private readonly SmtpServerConfiguration serverConfiguration;

        public SmtpConnection(TcpConnection tcpConnection, SmtpServerConfiguration serverConfiguration)
        {
            this.tcpConnection = tcpConnection;
            this.serverConfiguration = serverConfiguration;
        }

        public void SendMessage(String message)
        {
            tcpConnection.SendData(Encoding.ASCII.GetBytes(message + "\r\n"));
            Console.WriteLine("Sent: " + message);
        }

        public void ReceiveData(byte[] data)
        {
            dataBuffer.AddRange(data);
            if (CheckCommandComplete())
            {
                dataBuffer.Clear();
            }
        }

        private bool CheckCommandComplete()
        {
            if(dataBuffer.Count >= 2)
            {
                if (dataBuffer[dataBuffer.Count - 2] == '\r' && dataBuffer[dataBuffer.Count - 1] == '\n')
                    return true;
            }
            return false;
        }

    }
}
