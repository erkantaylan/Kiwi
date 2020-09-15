using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Prism.Commands;

namespace Kiwi.Wpf.Command
{
    [UsedImplicitly]
    public class CommandManager : ICommandManager
    {
        private ObservableCollection<CommandHolder> commands;

        /// <inheritdoc />
        public ObservableCollection<CommandHolder> Commands => commands ??= new ObservableCollection<CommandHolder>();

        /// <inheritdoc />
        public CommandHolder Create(string name, Action action, string description = null)
        {
            var o = new CommandHolder(name, action, description);
            Commands.Add(o);
            return o;
        }

        /// <inheritdoc />
        public CommandHolder Create(string name, DelegateCommand command, string description = null)
        {
            var o = new CommandHolder(name, command, description);
            Commands.Add(o);
            return o;
        }
    }
}