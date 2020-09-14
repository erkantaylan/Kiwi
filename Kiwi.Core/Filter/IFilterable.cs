using System;

namespace Kiwi.Core.Filter
{
    public interface IFilterable
    {
        Action<Predicate<object>> SetFilter { get; set; }
    }
}