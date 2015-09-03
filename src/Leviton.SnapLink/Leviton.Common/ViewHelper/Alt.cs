using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Leviton.Common.ViewHelper
{
    public partial class Alt
    {
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached(
            "IsVisible", typeof(object), typeof(Alt), new PropertyMetadata(default(object), IsVisibleChangedCallback));

        private static void IsVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;
            if (fe == null)
                return;

            fe.Visibility = e.NewValue is bool && (bool)e.NewValue
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public static void SetIsVisible(DependencyObject element, object value)
        {
            element.SetValue(IsVisibleProperty, value);
        }

        public static object GetIsVisible(DependencyObject element)
        {
            return (object)element.GetValue(IsVisibleProperty);
        }
    }

    public partial class Alt
    {
        public static readonly DependencyProperty IsNotVisibleProperty = DependencyProperty.RegisterAttached(
            "IsNotVisible", typeof(object), typeof(Alt), new PropertyMetadata(default(object), IsNotVisibleChangedCallback));

        private static void IsNotVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;
            if (fe == null)
                return;

            fe.Visibility = e.NewValue is bool && (bool)e.NewValue
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        public static void SetIsNotVisible(DependencyObject element, object value)
        {
            element.SetValue(IsNotVisibleProperty, value);
        }

        public static object GetIsNotVisible(DependencyObject element)
        {
            return (object)element.GetValue(IsNotVisibleProperty);
        }
    }

    public partial class Alt
    {
        #region RowDefinitions attached property
        public static string GetRowDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(RowDefinitionsProperty);
        }

        public static void SetRowDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(RowDefinitionsProperty, value);
        }

        public static readonly DependencyProperty RowDefinitionsProperty =
            DependencyProperty.RegisterAttached("RowDefinitions",
                                                typeof(string),
                                                typeof(Grid),
                                                new PropertyMetadata(string.Empty,
                                                                     RowDefinitions_PropertyChangedCallback));

        private static void RowDefinitions_PropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var grid = o as Grid;
            if (grid != null)
                grid.RowDefinitions.ParseAndFill(args.NewValue as string);
        }
        #endregion

        #region ColumnDefinitions attached property
        public static string GetColumnDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnDefinitionsProperty);
        }

        public static void SetColumnDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnDefinitionsProperty, value);
        }

        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.RegisterAttached("ColumnDefinitions",
                                                typeof(string),
                                                typeof(Grid),
                                                new PropertyMetadata(string.Empty,
                                                                     ColumnDefinitions_PropertyChangedCallback));

        private static void ColumnDefinitions_PropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var grid = o as Grid;
            if (grid != null)
                grid.ColumnDefinitions.ParseAndFill(args.NewValue as string);
        }
        #endregion
    }
}
