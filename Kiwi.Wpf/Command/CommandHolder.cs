using System;
using Prism.Commands;

namespace Kiwi.Wpf.Command
{
    public class CommandHolder
    {
        public CommandHolder(string name, DelegateCommand command, string description = null)
        {
            Name = name;
            Command = command;
            Description = description;
        }

        public CommandHolder(string name, Action action, string description = null) : this(name, new DelegateCommand(action), description)
        {
        }

        public string Name { get; }
        public DelegateCommand Command { get; }
        public string Description { get; }
    }
}