using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FileBrowser.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        public string Name { get; private set; }

        public string Path { get; set; }

        public string FileType { get; set; }

        private BitmapImage _bitmapImage;

        public BitmapImage BitmapImage
        {
            get
            {
                if (_bitmapImage == null)
                {
                    //(async () => await Initialize());
                    //Initialize().GetAwaiter().GetResult();
                    Initialize();
                }
                return _bitmapImage;
            }
            set { Set(ref _bitmapImage, value); }
        }

        public StorageFile StorageFile { get; set; }

        public ItemViewModel(StorageFile file)
        {
            Name = file.DisplayName;
            StorageFile = file;
            FileType = file.FileType;
            Path = file.Path;
        }

        public async Task Initialize()
        {
            BitmapImage = await GetThumbnailImageAsync(ThumbnailMode.ListView);
        }

        public async Task<BitmapImage> GetThumbnailImageAsync(ThumbnailMode mode)
        {
            if (StorageFile == null)
            {
                return null;
            }
            using (var thumbnail = await StorageFile.GetThumbnailAsync(mode))
            {
                if (thumbnail != null && thumbnail.Type == ThumbnailType.Image)
                {
                    var bitmap = new BitmapImage();
                    bitmap.SetSource(thumbnail);

                    return bitmap;
                }
                return null;
            }
        }
    }
}
