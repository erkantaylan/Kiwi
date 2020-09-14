using System.Windows;
using Kiwi.Wpf.Demos.Views;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;

namespace Kiwi.Wpf.Demos
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