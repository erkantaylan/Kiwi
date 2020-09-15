using System.Collections.ObjectModel;
using System.Windows;
using JetBrains.Annotations;
using Kiwi.Wpf.Command;
using Kiwi.Wpf.Filter;

namespace Kiwi.Wpf.Demos.ViewModels
{
    [UsedImplicitly]
    public class CommandSearchViewModel : FilterableViewModelBase
    {
        public CommandSearchViewModel(ICommandManager commandManager)
        {
            Commands = commandManager.Commands;
            commandManager.Create("command 1", () => { MessageBox.Show("command 1"); }, "my description 1");
            commandManager.Create("mmand 2", () => { MessageBox.Show("command 2"); }, "my description 2");
            commandManager.Create("coand 3", () => { MessageBox.Show("command 3"); }, "my description 3");
            commandManager.Create("comm 4", () => { MessageBox.Show("command 4"); }, "my description 4");
            commandManager.Create("command 5", () => { MessageBox.Show("command 5"); }, "my description 5");
            commandManager.Create("comand 6", () => { MessageBox.Show("command 6"); }, "my description 6");
            commandManager.Create("mnd 7", () => { MessageBox.Show("command 7"); }, "my description 7");
        }

        public ObservableCollection<CommandHolder> Commands { get; }

        /// <inheritdoc />
        protected override bool Filter(object o)
        {
            if (!(o is CommandHolder commandHolder))
            {
                return false;
            }

            return FilterHelper.Contains(
                Search,
                new[]
                {
                    commandHolder.Name,
                    commandHolder.Description
                });
        }
    }
}