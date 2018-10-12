using SMTPServer.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SMTPServer
{
    internal class SmtpCommandHandler
    {
        private readonly Dictionary<String, SmtpCommand> commands = new Dictionary<string, SmtpCommand>();
        public void Initialize()
        {
            Type smtpConnectionType = typeof(SmtpConnection);
            MethodInfo[] allMethods = smtpConnectionType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in allMethods)
            {
                foreach (SmtpCommandMethod attribute in method.GetCustomAttributes(typeof(Attributes.SmtpCommandMethod), true))
                {
                    SmtpCommand command = new SmtpCommand(attribute.Command, attribute.MinimumParameterCount, method);
                    command.AllowedConnectionStates.AddRange(GetAllowedConnectionStates(method));
                    commands.Add(command.Name, command);
                }
            }
        }

        public SmtpCommand GetCommand(String commandName)
        {
            commandName = commandName.ToUpper();
            if (!commands.ContainsKey(commandName))
                return null;
            else
                return commands[commandName];
        }

        private List<ConnectionState> GetAllowedConnectionStates(MethodInfo mi)
        {
            List<ConnectionState> allowedConnectionStates = new List<ConnectionState>();
            foreach (AllowConnectionState attr in mi.GetCustomAttributes(typeof(AllowConnectionState), true))
            {
                allowedConnectionStates.Add(attr.ConnectionState);
            }
            return allowedConnectionStates;
        }


    }
}
