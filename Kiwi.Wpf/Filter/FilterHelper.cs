using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiwi.Wpf.Filter
{
    public static class FilterHelper
    {
        public static bool Contains(string filter, IEnumerable<string> items)
        {
            filter = filter.ToLower();
            return (from i in items where i != null select i.ToLower()).Any(item => item.Contains(filter));
        }

        public static bool Contains(IEnumerable<string> filters, IList<string> items)
        {
            return filters.Select(f => Contains((string) f, items)).Any(contains => contains);
        }

        public static IEnumerable<string> SplitFilter(string filter)
        {
            return filter.Split(
                new[]
                {
                    ' ',
                    ','
                },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}