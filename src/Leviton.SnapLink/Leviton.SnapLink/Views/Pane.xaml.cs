using Windows.UI.Xaml;

namespace Leviton.SnapLink.Views
{
    public sealed partial class Pane
    {
        public Pane()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            var shell = Window.Current.Content as Shell;
            shell.TogglePane();
        }
    }
}
