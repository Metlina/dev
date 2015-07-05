using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using FileBrowser.ViewModel;

namespace FileBrowser.View
{
    public sealed partial class File : Page
    {
        public File()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var file = e.Parameter as ItemViewModel;
            if (file != null)
            {
                Image.Source = await file.GetThumbnailImageAsync(ThumbnailMode.SingleItem);
            }
        }
    }
}
