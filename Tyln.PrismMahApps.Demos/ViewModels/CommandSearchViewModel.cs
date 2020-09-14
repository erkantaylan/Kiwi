using System.Windows;
using JetBrains.Annotations;
using Prism.Mvvm;

namespace Tyln.PrismMahApps.Demos.ViewModels
{
    [UsedImplicitly]
    public class CommandSearchViewModel : BindableBase
    {
        public CommandSearchViewModel()
        {
            Command1 = new SearchableCommand("Command 1", () => { MessageBox.Show("Command 1"); });
            Command2 = new SearchableCommand("Command 2", () => { MessageBox.Show("Command 2"); });
            Command3 = new SearchableCommand("Command 3", () => { MessageBox.Show("Command 3"); });
            Command4 = new SearchableCommand("Command 4", () => { MessageBox.Show("Command 4"); });
            Command5 = new SearchableCommand("Command 5", () => { MessageBox.Show("Command 5"); });
            Command6 = new SearchableCommand("Command 6", () => { MessageBox.Show("Command 6"); });
        }

        public SearchableCommand Command1 { get; }
        public SearchableCommand Command2 { get; }
        public SearchableCommand Command3 { get; }
        public SearchableCommand Command4 { get; }
        public SearchableCommand Command5 { get; }
        public SearchableCommand Command6 { get; }
    }
}