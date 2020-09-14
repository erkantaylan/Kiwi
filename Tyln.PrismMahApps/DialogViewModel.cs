using System;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Tyln.PrismMahApps
{
    public abstract class DialogViewModel<TOpen, TClose> : BindableBase, IDialogViewModel<TOpen>
    {
        private readonly TaskCompletionSource<TClose> tcs;

        protected DialogViewModel()
        {
            tcs = new TaskCompletionSource<TClose>();
        }

        public Task<TClose> ResultParameterTask => tcs.Task;

        public event EventHandler Closed;
        public abstract void OnDialogOpened(TOpen parameter);

        protected void Close(TClose parameters = default)
        {
            tcs.SetResult(parameters);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class DialogViewModel<TClose> : BindableBase, IDialogViewModel
    {
        private readonly TaskCompletionSource<TClose> tcs;

        protected DialogViewModel()
        {
            tcs = new TaskCompletionSource<TClose>();
        }

        public Task<TClose> ResultParameterTask => tcs.Task;

        public event EventHandler Closed;
        public abstract void OnDialogOpened();

        protected void Close(TClose parameters = default)
        {
            tcs.SetResult(parameters);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}