using System.Windows;
using Kiwi.PrismMahApps.Demos.Views;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;

namespace Kiwi.PrismMahApps.Demos
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry registry)
        {
            registry.RegisterInstance(DialogCoordinator.Instance);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
    }
}