using System.Windows;
using DryIoc;
using JetBrains.Annotations;
using Kiwi.Wpf.Demos.Dialogs;
using Prism.Commands;
using Prism.Mvvm;

namespace Kiwi.Wpf.Demos.ViewModels
{
    [UsedImplicitly]
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IResolver resolver;
        private string title;

        public ShellWindowViewModel(IResolver resolver)
        {
            this.resolver = resolver;
            title = "Prism MahApps Demo";
        }

        public DelegateCommand ShowSimleDialogCommand => new DelegateCommand(async () =>
        {
            SimpleMetroDialog dialog = resolver.Resolve<SimpleMetroDialog>();
            string dialogResult = await dialog.ShowDialogAsync<string, string>("Coolest parameter ever!");
            if (string.IsNullOrWhiteSpace(dialogResult))
            {
                MessageBox.Show("You have canceled the simplest dialog ever!");
            }
            else
            {
                MessageBox.Show(dialogResult);
            }
        });

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}