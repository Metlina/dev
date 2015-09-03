using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;

namespace Leviton.Common.Mvvm
{
    public class NavigateCommand<TPage> : RelayCommand
        where TPage : Page
    {
        public NavigateCommand()
            : base(Execute)
        {

        }

        private static void Execute()
        {
            //+Windows.UI.Xaml.Window.Content.get returned { Leviton.SnapLink.Views.Shell}
            //Leviton.SnapLink.Views.Shell
            var frame = Window.Current.Content as Frame;
            var splitView = Window.Current.Content as SplitView;
            //var shell = Window.Current.Content as Leviton.SnapLink.Views.Shell;
            if (frame != null)
            {
                frame.Navigate(typeof(TPage));
            }
            else if (splitView != null)
            {
                //frame = Window.Current.Content as Frame;
                //Window.Current.Content = new Shell(frame);
                frame.Navigate(typeof(TPage));
            }
        }
    }

    public class NavigateCommand<TPage, TParameter> : RelayCommand<TParameter>
       where TPage : Page
    {
        public NavigateCommand()
            : base(Execute)
        {

        }

        private static void Execute(TParameter parameter)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(TPage), parameter);
            }
        }
    }
}
