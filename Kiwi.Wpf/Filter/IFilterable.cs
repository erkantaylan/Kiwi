using System;

namespace Kiwi.Wpf.Filter
{
    public interface IFilterable
    {
        Action<Predicate<object>> SetFilter { get; set; }
    }
}