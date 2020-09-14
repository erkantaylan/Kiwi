using MahApps.Metro.Controls.Dialogs;

namespace Kiwi.Mvvm
{
    public static class MetroDialogSettingsFactory
    {
        public static MetroDialogSettings Create()
        {
            return new MetroDialogSettings {AnimateHide = true, AnimateShow = false};
        }
    }
}