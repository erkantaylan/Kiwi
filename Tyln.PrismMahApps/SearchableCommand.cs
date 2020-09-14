using System;
using System.Collections.ObjectModel;
using Prism.Commands;

namespace Tyln.PrismMahApps
{
    public class SearchableDelegateCommand : DelegateCommand
    {
        private static ObservableCollection<SearchableDelegateCommand> commands;

        public SearchableDelegateCommand(string name, Action executeMethod) : base(executeMethod)
        {
            Name = name;
            Commands.Add(this);
        }

        public SearchableDelegateCommand(string name, Action executeMethod, Func<bool> canExecuteMethod) : base(
            executeMethod,
            canExecuteMethod)
        {
            Name = name;
            Commands.Add(this);
        }

        public static ObservableCollection<SearchableDelegateCommand> Commands => commands ?? (commands = new ObservableCollection<SearchableDelegateCommand>());

        public string Name { get; }
    }
}