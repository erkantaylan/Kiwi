using Prism.Regions;

namespace Kiwi.Wpf.Demos.Views
{
    public partial class ShellWindow
    {
        public ShellWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion("CommandSearchRegion", typeof(CommandSearchView));
            regionManager.RegisterViewWithRegion("ValidationRegion", typeof(ValidationsView));
        }
    }
}