using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kiwi.PrismMahApps
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
                throw new DialogViewModelNotFoundException(dialog.DataContext.GetType().ToString());
            }

            if (settings == null)
            {
                settings = MetroDialogSettingsFactory.Create();
            }

            MetroWindow window = WindowHelper.GetMainWindow();
            vm.OnDialogOpened(parameters);
            await window.ShowMetroDialogAsync(dialog, settings);
            TClose resultParameters = await vm.ResultParameterTask;
            await window.HideMetroDialogAsync(dialog, settings);
            return resultParameters;
        }

        public static async Task<TClose> ShowDialogAsync<TClose>(this CustomDialog dialog, MetroDialogSettings settings = null)
        {
            if (!(dialog.DataContext is DialogViewModel<TClose> vm))
            {
                throw new DialogViewModelNotFoundException(dialog.DataContext.GetType().ToString());
            }

            if (settings == null)
            {
                settings = MetroDialogSettingsFactory.Create();
            }

            MetroWindow window = WindowHelper.GetMainWindow();
            vm.OnDialogOpened();
            await window.ShowMetroDialogAsync(dialog, settings);
            TClose resultParameters = await vm.ResultParameterTask;
            await window.HideMetroDialogAsync(dialog, settings);
            return resultParameters;
        }
    }

    [Serializable]
    public class DialogViewModelNotFoundException : Exception
    {
        public DialogViewModelNotFoundException() { }
        public DialogViewModelNotFoundException(string message) : base(message) { }
        public DialogViewModelNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected DialogViewModelNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}