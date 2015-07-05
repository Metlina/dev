using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FileBrowser.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<FolderViewModel> Folders { get; private set; }

        private string _folderName;

        public string FolderName
        {
            get { return _folderName; }
            set { Set(ref _folderName, value); }
        }
        
        private bool _isListView;

        public bool IsListView
        {
            get { return _isListView; }
            set { Set(ref _isListView, value); }
        }

        public MainViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();
            ListToGridCommand = new RelayCommand(ListToGrid);
        }

        public ICommand ListToGridCommand { get; set; }

        public void ListToGrid()
        {
            IsListView = !IsListView;
        }

        public async Task LoadAsync()
        {
            StorageFolder pictureStorageFolder = KnownFolders.PicturesLibrary;
            StorageFolder videoStorageFolder = KnownFolders.VideosLibrary;

            IReadOnlyList<StorageFile> pictureFiles = await pictureStorageFolder.GetFilesAsync();
            IReadOnlyList<StorageFile> videoFolders = await videoStorageFolder.GetFilesAsync();

            var cameraRollFolder = await KnownFolders.CameraRoll.GetFoldersAsync();
            //var documentLibraryFolder = await KnownFolders.DocumentsLibrary.GetFoldersAsync();
            //var homeGroupFolder = await KnownFolders.HomeGroup.GetFoldersAsync();
            //var mediaServerFolder = await KnownFolders.MediaServerDevices.GetFoldersAsync();
            //var musicLibraryFolder = await KnownFolders.MusicLibrary.GetFoldersAsync();
            var pictureLibraryFolder = await KnownFolders.PicturesLibrary.GetFoldersAsync();
            //var removableDevicesFolder = await KnownFolders.RemovableDevices.GetFoldersAsync();
            var savedPicturesFolder = await KnownFolders.SavedPictures.GetFoldersAsync();
            var videoLibraryFolder = await KnownFolders.VideosLibrary.GetFoldersAsync();

            foreach (var cameraRoll in cameraRollFolder)
            {
                Folders.Add(new FolderViewModel(cameraRoll));
            }

            //foreach (var documentLibrary in documentLibraryFolder)
            //{
            //    Folders.Add(new FolderViewModel(documentLibrary));
            //}

            //foreach (var homeGroup in homeGroupFolder)
            //{
            //    Folders.Add(new FolderViewModel(homeGroup));
            //}

            //foreach (var mediaServer in mediaServerFolder)
            //{
            //    Folders.Add(new FolderViewModel(mediaServer));
            //}

            //foreach (var musicLibrary in musicLibraryFolder)
            //{
            //    Folders.Add(new FolderViewModel(musicLibrary));
            //}

            foreach (var pictureLibrary in pictureLibraryFolder)
            {
                Folders.Add(new FolderViewModel(pictureLibrary));
            }

            //foreach (var removableDevices in removableDevicesFolder)
            //{
            //    Folders.Add(new FolderViewModel(removableDevices));
            //}

            foreach (var savedPictures in savedPicturesFolder)
            {
                Folders.Add(new FolderViewModel(savedPictures));
            }

            foreach (var videoLibrary in videoLibraryFolder)
            {
                Folders.Add(new FolderViewModel(videoLibrary));
            }
            //foreach (var folder in pictureFolders)
            //{
            //    foreach (var picture in await folder.GetFilesAsync())
            //    {
            //        Items.Add(new ItemViewModel(picture, FileType.PictureLibrary));
            //    }
            //}
        }
    }
}