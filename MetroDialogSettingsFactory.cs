using MahApps.Metro.Controls.Dialogs;

namespace Tyln.PrismMahApps
{
    public static class MetroDialogSettingsFactory
    {
        public static MetroDialogSettings Create()
        {
            return new MetroDialogSettings {AnimateHide = true, AnimateShow = false};
        }
    }
}