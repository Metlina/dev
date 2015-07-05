using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.PushNotifications;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FileBrowser.ViewModel
{
    public class FolderViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string FolderLocation { get; set; }

        private string _folderName;

        public string FolderName
        {
            get { return _folderName; }
            set { Set(ref _folderName, value); }
        }
        
        public StorageFolder StorageFolder { get; set; }

        private StorageFile _storageFile;

        public StorageFile StorageFile
        {
            get { return _storageFile; }
            set { Set(ref _storageFile, value); }
        }
        
        public ICommand ListToGridCommand { get; set; }

        public ICommand ShareCommand { get; set; }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private bool _isListView;

        public bool IsListView
        {
            get { return _isListView; }
            set { Set(ref _isListView, value); }
        }

        private bool _isShareView;

        public bool IsShareView
        {
            get { return _isShareView; }
            set { Set(ref _isShareView, value); }
        }
        
        
        public FolderViewModel(StorageFolder folder)
        {
            string trim = folder.Path.ToString();
            string pom = trim.Remove(1);
            string location;
            if (pom == "C")
            {
                location = "Phone";
            }
            else
            {
                location = "SD card";
            }
            Items = new ObservableCollection<ItemViewModel>();
            Name = folder.Name;
            FolderLocation = location;
            FolderName = folder.Name;
            StorageFolder = folder;
            ListToGridCommand = new RelayCommand(ListToGrid);
            ShareCommand = new RelayCommand(ShareToView);
            //Initialize();
        }

        private async Task Initialize()
        {
            await LoadAsync();
        }

        public void ShareToView()
        {
            IsShareView = !IsShareView;
        }

        public void ListToGrid()
        {
            IsListView = !IsListView;
        }

        private int _folderCount;

        public int FolderCount
        {
            get
            {
                Initialize();
                return _folderCount;
            }
            set { Set(ref _folderCount, value); }
        }

        public async Task LoadAsync()
        {
            //StorageFolder pictureFolder = KnownFolders.PicturesLibrary;
            //StorageFolder videoFolder = KnownFolders.VideosLibrary;
            //StorageFolder = KnownFolders.PicturesLibrary;

            Items.Clear();

            IReadOnlyList<StorageFile> pictureFiles = await StorageFolder.GetFilesAsync();

            FolderCount = pictureFiles.Count;

            foreach (var picture in pictureFiles)
            {
                if (picture.FileType != ".dng")
                {
                    //Items.Add(new ItemViewModel(picture, FileType.PictureLibrary));
                    Items.Add(new ItemViewModel(picture));
                }
                //Items.Add(new ItemViewModel(picture, FileType.PictureLibrary));
            }

            //StorageItemThumbnail thumbnailFiles = await StorageFolder.GetThumbnailAsync(ThumbnailMode.PicturesView);

            //StorageFolder = KnownFolders.VideosLibrary;
            //IReadOnlyList<StorageFile> videoFolders = await StorageFolder.GetFilesAsync();

            //foreach (var video in videoFolders)
            //{
            //    Items.Add(new ItemViewModel(video, FileType.VideoLibrary));
            //}
        }
    }

    //public enum FileType
    //{
    //    PictureLibrary,
    //    VideoLibrary
    //};
}
