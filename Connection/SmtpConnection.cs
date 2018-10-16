using System;
using System.Collections.Generic;
using System.Text;
using TCPServer;
using System.Linq;

namespace SMTPServer
{
    internal partial class SmtpConnection
    {
        public ConnectionState ConnectionState { get; private set; } = ConnectionState.Established;

        internal SmtpServerConfiguration ServerConfiguration { get => serverConfiguration; }

        private readonly TcpConnection tcpConnection;
        private readonly List<byte> dataBuffer = new List<byte>();
        private readonly SmtpServerConfiguration serverConfiguration;
        private readonly SmtpCommandHandler commandHandler;

        private readonly Mail mail = new Mail();

        public SmtpConnection(TcpConnection tcpConnection, SmtpServerConfiguration serverConfiguration, SmtpCommandHandler commandHandler)
        {
            this.tcpConnection = tcpConnection;
            this.serverConfiguration = serverConfiguration;
            this.commandHandler = commandHandler;
        }

        public void SendMessage(String message)
        {
            tcpConnection.SendData(Encoding.ASCII.GetBytes(message + "\r\n"));
            Logger.Log("Sent: " + message);
        }

        public void ReceiveData(byte[] data)
        {
            dataBuffer.AddRange(data);
            if (!CheckCommandComplete())
                return;
            Logger.Log("Received: " + Encoding.ASCII.GetString(dataBuffer.ToArray()));
            if (this.ConnectionState != ConnectionState.ReceivingMailData)
            {
                String commandMessage = Encoding.ASCII.GetString(dataBuffer.ToArray(), 0, dataBuffer.Count - 2);
                String[] commandParts = commandMessage.Split(' ');
                SmtpCommand command = GetCommand(commandParts);
                if (command != null)
                {
                    if (command.AllowEveryConnectionState || command.AllowedConnectionStates.Contains(this.ConnectionState))
                        command.Method.Invoke(this, new object[] { commandMessage.Substring(command.Name.Length).TrimStart() });
                    else
                        SendBadCommandSequenceReply();
                }
            }
            else if (this.ConnectionState == ConnectionState.ReceivingMailData)
            {
                mail.SetMessage(dataBuffer.SkipLast(5).ToArray());
                SendOkReply();
            }


            dataBuffer.Clear();
        }

        private SmtpCommand GetCommand(String[] commandParts)
        {
            SmtpCommand command = null;
            Int32 commandLength = 0;
            foreach (String commandPart in commandParts)
                commandLength += commandPart.Length;


            if (commandParts.Length < 1)
                SendCommandUnrecognizedReply();
            else if (commandLength > ServerConfiguration.MaximumLineLength)
                SendLineTooLongReply();
            else
            {
                command = commandHandler.GetCommand(commandParts[0]);
                if (command == null)
                    SendCommandUnrecognizedReply();
                else if (commandParts.Length - 1 < command.MinimumParameterCount)
                {
                    SendParameterSyntaxErrorReply();
                    command = null;
                }
            }
            return command;
        }

        private bool CheckCommandComplete()
        {
            if (ConnectionState == ConnectionState.ReceivingMailData)
            {
                if (dataBuffer.Count >= 5)
                {
                    if (dataBuffer[dataBuffer.Count - 5] == '\r' && dataBuffer[dataBuffer.Count - 4] == '\n'
                        && dataBuffer[dataBuffer.Count - 3] == '.'
                        && dataBuffer[dataBuffer.Count - 2] == '\r' && dataBuffer[dataBuffer.Count - 1] == '\n')
                        return true;
                }
            }
            else
            {
                if (dataBuffer.Count >= 2)
                {
                    if (dataBuffer[dataBuffer.Count - 2] == '\r' && dataBuffer[dataBuffer.Count - 1] == '\n')
                        return true;
                }
            }
            
            return false;
        }

    }
}
