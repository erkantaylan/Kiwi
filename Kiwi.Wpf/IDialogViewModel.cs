using System;

namespace Kiwi.Wpf
{
    public interface IDialogViewModel<in TOpen>
    {
        event EventHandler Closed;

        void OnDialogOpened(TOpen parameter);
    }
    
    public interface IDialogViewModel
    {
        event EventHandler Closed;

        void OnDialogOpened();
    }
}