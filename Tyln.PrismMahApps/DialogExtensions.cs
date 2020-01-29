using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Tyln.PrismMahApps
{
    public static class DialogExtensions
    {
        public static async Task<TClose> ShowDialogAsync<TOpen, TClose>(
            this CustomDialog dialog
            , TOpen parameters = default
            , MetroDialogSettings settings = null)
        {
            if (!(dialog.DataContext is DialogViewModel<TOpen, TClose> vm))
            {
                return default;
            }

            if (settings == null)
            {
                settings = MetroDialogSettingsFactory.Create();
            }

            MetroWindow window = WindowHelper.GetMainWindow();
            vm.OnDialogOpened(parameters);
            await window.ShowMetroDialogAsync(dialog, settings);
            TClose resultParameters = await vm.Task;
            await window.HideMetroDialogAsync(dialog, settings);
            return resultParameters;
        }
    }
}