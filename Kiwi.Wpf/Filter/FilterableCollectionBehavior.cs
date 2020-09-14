using System.Windows;
using System.Windows.Controls.Primitives;

namespace Kiwi.Wpf.Filter
{
    public class FilterableCollectionBehavior : Behavior<Selector>
    {
        private IFilterable filterable;

        /// <inheritdoc />
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObjectOnLoaded;
        }

        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is Selector control))
            {
                return;
            }

            if (!(control.DataContext is IFilterable o))
            {
                return;
            }

            filterable = o;

            filterable.SetFilter += filter =>
            {
                if (control.Items.Filter == null && filter == null)
                {
                    return;
                }

                control.Items.Filter = filter;
            };
        }
    }
}