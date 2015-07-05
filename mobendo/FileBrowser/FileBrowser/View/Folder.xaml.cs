using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using FileBrowser.ViewModel;

namespace FileBrowser.View
{
    public sealed partial class Folder : Page
    {
        private ItemViewModel _itemViewModel;

        public Folder()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var folder = e.Parameter as FolderViewModel;
            if (e.NavigationMode == NavigationMode.New)
            {
                if (folder != null)
                {
                    DataContext = folder;
                    //_f = folder;
                    await folder.LoadAsync();
                    ProgressRing.Visibility = Visibility.Collapsed;
                }
                if (folder != null && folder.Items.Count == 0)
                {
                    EmptyTextBlock.Visibility = Visibility.Visible;
                }
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                DataContext = folder;
                ProgressRing.Visibility = Visibility.Collapsed;
            }
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            //Frame.Navigate(typeof(File), e.ClickedItem);
            if (ListView.SelectionMode == ListViewSelectionMode.Single || GridView.SelectionMode == ListViewSelectionMode.Single)
            {
                Frame.Navigate(typeof(File), e.ClickedItem);
            }
            else
            {
                ListView.SelectedItem = e.ClickedItem;
                _itemViewModel = (ItemViewModel) e.ClickedItem;
            }
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

        private void UIElement_OnHolding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
            if (senderElement != null) _itemViewModel = (ItemViewModel) senderElement.DataContext;
        }

        private void MenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            RegisterForShare();
        }

        private void RegisterForShare()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,
                DataRequestedEventArgs>(ShareStorageItemsTextHandler);
            DataTransferManager.ShowShareUI();
        }

        private void ShareStorageItemsTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "Share file from file browser";
            request.Data.Properties.Description = "Sharing files from file browser";

            DataRequestDeferral deferral = request.GetDeferral();

            try
            {
                List<IStorageItem> storageItems = new List<IStorageItem> {_itemViewModel.StorageFile};
                request.Data.SetStorageItems(storageItems);
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.ToString());
                messageDialog.ShowAsync();
            }
            finally
            {
                deferral.Complete();
            }
        }

        private void ButtonBaseSelectOnClick(object sender, RoutedEventArgs e)
        {
            //if (ListView.SelectionMode == ListViewSelectionMode.None)
            //{
            //    ListView.SelectionMode = ListViewSelectionMode.Multiple;
            //}
            //else if (ListView.SelectionMode == ListViewSelectionMode.Multiple)
            //{
            //    ListView.SelectionMode = ListViewSelectionMode.None;
            //}
            //else
            //{
            //    ListView.SelectionMode = ListViewSelectionMode.Multiple;
            //}
            if (ListView.SelectionMode == ListViewSelectionMode.Single)
            {
                ListView.SelectionMode = ListViewSelectionMode.Multiple;
                GridView.SelectionMode = ListViewSelectionMode.Multiple;
            }
            else
            {
                ListView.SelectionMode = ListViewSelectionMode.Single;
                GridView.SelectionMode = ListViewSelectionMode.Single;
            }
        }

        private void ButtonBaseShare_OnClick(object sender, RoutedEventArgs e)
        {
            //if (sender != null) _itemViewModel = (ItemViewModel)sender.DataContext;
            FrameworkElement senderElement = sender as FrameworkElement;
            try
            {
                //if (senderElement != null) _itemViewModel = (ItemViewModel) senderElement.DataContext;
                RegisterForShare();
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.ToString());
                messageDialog.ShowAsync();
            }
        }

        private void ButtonBaseCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ListView.SelectionMode = ListViewSelectionMode.Single;
            GridView.SelectionMode = ListViewSelectionMode.Single;
        }

        private void MenuFlyoutItemDelete_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
    