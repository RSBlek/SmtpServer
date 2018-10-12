using System;

namespace SMTPServer.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException(String commandName) : base("Command " + commandName + " not found")
        {
        }
    }
}
