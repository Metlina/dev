using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FileBrowser.View;
using FileBrowser.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace FileBrowser
{
    public sealed partial class MainPage : Page
    {
        private bool _inizialized = false;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!_inizialized)
            {
                _inizialized = true;
                var vm = SimpleIoc.Default.GetInstance<MainViewModel>();
                await vm.LoadAsync();
                ProgressRing.Visibility = Visibility.Collapsed;
            }
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(Folder), e.ClickedItem);
        }

        private void AppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (AppBarButton.Label == "thumbnail")
            {
                AppBarButton.Icon = new SymbolIcon(Symbol.List);
                AppBarButton.Label = "list";
            }
            else
            {
                AppBarButton.Icon = new SymbolIcon(Symbol.ViewAll);
                AppBarButton.Label = "thumbnail";
            }
        }
    }
}
