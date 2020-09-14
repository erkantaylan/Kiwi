using Prism.Regions;

namespace Kiwi.Wpf.Demos.Views
{
    public partial class ShellWindow
    {
        public ShellWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion("CommandsRegion", typeof(CommandSearchView));
            regionManager.RegisterViewWithRegion("ValidationRegion", typeof(ValidationsView));
        }
    }
}