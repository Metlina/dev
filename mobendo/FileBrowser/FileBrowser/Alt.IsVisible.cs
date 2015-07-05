using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FileBrowser
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
            element.SetValue(IsVisibleProperty, value);
        }

        public static object GetIsNotVisible(DependencyObject element)
        {
            return (object)element.GetValue(IsNotVisibleProperty);
        }
    }

    //public partial class Alt
    //{
    //    public static readonly DependencyProperty IsHitTestVisibleProperty = DependencyProperty.RegisterAttached(
    //        "IsHitTestVisible", typeof (object), typeof (Alt), new PropertyMetadata(default(object), IsHitTestVisibleChangedCallback));

    //    private static void IsHitTestVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        var fe = d as FrameworkElement;
    //        if (fe == null)
    //            return;

    //        fe.IsHitTestVisible = e.NewValue is bool && (bool) e.NewValue
    //            ? IsHitTestVisible.True
    //            : IsHitTestVisible.False;
    //    }

    //    public static void SetIsHitTestVisible(DependencyObject element, object value)
    //    {
    //        element.SetValue(IsHitTestVisibleProperty, value);
    //    }

    //    public static object GetIsHitTestVisible(DependencyObject element)
    //    {
    //        return (object) element.GetValue(IsHitTestVisibleProperty);
    //    }
    //}
    //public partial class Alt
    //{
    //    public static readonly DependencyProperty IsHitTestNotVisibleProperty = DependencyProperty.RegisterAttached(
    //        "IsHitTestNotVisible", typeof(object), typeof(Alt), new PropertyMetadata(default(object), IsHitTestNotVisibleChangedCallback));

    //    private static void IsHitTestNotVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        var fe = d as FrameworkElement;
    //        if (fe == null)
    //            return;

    //        fe.IsHitTestVisible = e.NewValue is bool && (bool)e.NewValue
    //            ? IsHitTestVisible.False
    //            : IsHitTestVisible.True;
    //    }

    //    public static void SetIsHitTestNotVisible(DependencyObject element, object value)
    //    {
    //        element.SetValue(IsHitTestVisibleProperty, value);
    //    }

    //    public static object GetIsHitTestNotVisible(DependencyObject element)
    //    {
    //        return (object)element.GetValue(IsHitTestNotVisibleProperty);
    //    }
    //}
}
