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

        public Task<TClose> Task => tcs.Task;

        public event EventHandler Closed;
        public abstract void OnDialogOpened(TOpen parameter);

        protected void Close(TClose parameters = default)
        {
            tcs.SetResult(parameters);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}