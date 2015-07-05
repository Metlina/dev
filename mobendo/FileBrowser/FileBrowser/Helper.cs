//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Data;

//namespace FileBrowser
//{
//    public class Helper
//    {
//        public static string GetIsSelectedContainerBinding(DependencyObject obj)
//        {
//            return (string)obj.GetValue(IsSelectedContainerBindingProperty);
//        }

//        public static void SetIsSelectedContainerBinding(DependencyObject obj, string value)
//        {
//            obj.SetValue(IsSelectedContainerBindingProperty, value);
//        }

//        public static readonly DependencyProperty IsSelectedContainerBindingProperty = DependencyProperty.RegisterAttached("IsSelectedContainerBinding", typeof(string), typeof(helper), new PropertyMetadata(null, IsSelectedContainerBindingPropertyChangedCallback));

//        public static void IsSelectedContainerBindingPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            BindingOperations.SetBinding(d, ListViewItem.IsSelectedProperty, new Binding()
//            {
//                Source = d,
//                Path = new PropertyPath("Content." + e.NewValue),
//                Mode = BindingMode.TwoWay
//            });
//        }
//    }
//}
