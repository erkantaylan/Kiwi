using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;

namespace Tyln.PrismMahApps
{
    public static class WindowHelper
    {
        public static MetroWindow GetMainWindow()
        {
            return Application.Current.Windows.OfType<MetroWindow>().First();
        }
    }
}