using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using Tyln.PrismMahApps.Demos.Views;

namespace Tyln.PrismMahApps.Demos
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