using System;
using Prism.Mvvm;

namespace Kiwi.Wpf.Filter
{
    public abstract class FilterableViewModelBase : BindableBase, IFilterable
    {
        private string search;

        protected FilterableViewModelBase()
        {
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Search))
                {
                    ChangeFilter();
                }
            };
        }

        public virtual string Search
        {
            get => search;
            set => SetProperty(ref search, value);
        }

        /// <inheritdoc />
        public Action<Predicate<object>> SetFilter { get; set; }

        protected virtual void ChangeFilter()
        {
            if (Search.Length == 0)
            {
                SetFilter?.Invoke(null);
            }
            else
            {
                SetFilter?.Invoke(Filter);
            }
        }

        protected abstract bool Filter(object o);
    }
}