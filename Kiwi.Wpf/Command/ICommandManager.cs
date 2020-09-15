using System;
using System.Collections.ObjectModel;
using Prism.Commands;

namespace Kiwi.Wpf.Command
{
    public interface ICommandManager
    {
        public ObservableCollection<CommandHolder> Commands { get; }
        CommandHolder Create(string name, Action action, string description = null);
        CommandHolder Create(string name, DelegateCommand command, string description = null);
    }
}