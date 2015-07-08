using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using TestXml.ViewModel;

namespace TestXml.View
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ButtonLoad_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = SimpleIoc.Default.GetInstance<MainViewModel>();
            vm.LoadAsync();
        }
    }
}
