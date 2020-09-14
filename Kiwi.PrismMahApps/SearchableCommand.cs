using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Prism.Commands;

namespace Kiwi.PrismMahApps
{
    public class SearchableCommand : DelegateCommand
    {
        private static ObservableCollection<SearchableCommand> commands;

        public SearchableCommand(string name, Action executeMethod) : base(executeMethod)
        {
            Name = name;
            Commands.Add(this);
        }

        public SearchableCommand(string name, Action executeMethod, Func<bool> canExecuteMethod) : base(
            executeMethod,
            canExecuteMethod)
        {
            Name = name;
            Commands.Add(this);
        }

        public static ObservableCollection<SearchableCommand> Commands => commands ?? (commands = new ObservableCollection<SearchableCommand>());

        public string Name { get; }
        
        public new SearchableCommand ObservesProperty<T>(Expression<Func<T>> propertyExpression)
        {
            ObservesPropertyInternal(propertyExpression);
            return this;
        }
    }
}