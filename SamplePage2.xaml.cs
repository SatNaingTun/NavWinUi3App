using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Search;
using Windows.Storage;
using Windows.UI.Popups;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NavWinUi3App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SamplePage2 : Page
    {

        public ObservableCollection<ImageFileInfo> Images { get; } =
            new ObservableCollection<ImageFileInfo>();
        public string folderPath = Package.Current.InstalledPath + "\\Assets\\SampleImages";

        public SamplePage2()
        {
            this.InitializeComponent();
            GetItemsAsync();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
        private async Task GetItemsAsync()
        {
            
            
            StorageFolder appInstalledFolder = Package.Current.InstalledLocation;
            //StorageFolder picturesFolder = await appInstalledFolder.GetFolderAsync(folderPath);
            StorageFolder picturesFolder=await StorageFolder.GetFolderFromPathAsync(folderPath);
            

            var result = picturesFolder.CreateFileQueryWithOptions(new QueryOptions());

            IReadOnlyList<StorageFile> imageFiles = await result.GetFilesAsync();
            foreach (StorageFile file in imageFiles)
            {
                
                Images.Add(await LoadImageInfoAsync(file));
            }

            ImageGridView.ItemsSource = Images;
        }

        public async static Task<ImageFileInfo> LoadImageInfoAsync(StorageFile file)
        {
            var properties = await file.Properties.GetImagePropertiesAsync();
            ImageFileInfo info = new(properties,
                                     file, file.DisplayName, file.DisplayType);

           
            return info;
        }

        private void ImageGridView_ContainerContentChanging(
    ListViewBase sender,
    ContainerContentChangingEventArgs args)
        {
          
            if (args.InRecycleQueue)
            {
                var templateRoot = args.ItemContainer.ContentTemplateRoot as Grid;
                var image = templateRoot.FindName("ItemImage") as Image;
                image.Source = null;
            }

            if (args.Phase == 0)
            {
                args.RegisterUpdateCallback(ShowImage);
                args.Handled = true;
            }

        }

        private async void ShowImage(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (args.Phase == 1)
            {
                // It's phase 1, so show this item's image.
                var templateRoot = args.ItemContainer.ContentTemplateRoot as Grid;
                var image = templateRoot.FindName("ItemImage") as Image;
                var item = args.Item as ImageFileInfo;
                image.Source = await item.GetImageThumbnailAsync();
            }
        }

        private async void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFileInfo info = (ImageFileInfo)e.ClickedItem;
            ListPage listPage = new ListPage();


            ContentDialog dialog = new ContentDialog()
            {
                Title = "MessageBox",
                Content = "Do you want to add " + info.ImageTitle+" to list",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No",
                DefaultButton=ContentDialogButton.Primary,
                XamlRoot = this.XamlRoot
            };
            var result = await dialog.ShowAsync();
            if(result==ContentDialogResult.Primary)
            {
                listPage.AddItem(info.ImageTitle,info.ImageFile.ToString() );
                this.Content = listPage;
            }
            


            //if (info != null)
            //{
            //    Debug.WriteLine(info.ImageTitle);
            //}
            //Debug.WriteLine(e.ClickedItem);

        }
    

        private void ImageGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine(e.OriginalSource);
            //var gridViewItem = ImageGridView.ContainerFromItem(ImageGridView.SelectedItem) as GridViewItem;

            //string str = gridViewItem.Tag.ToString();

            // passing string "str" in   
            // switch statement  
            //switch (str)
            //{
            //    case "1":
            //        Debug.WriteLine("It is 1");
            //        break;

            //    case "2":
            //        Debug.WriteLine("It is 2");
            //        break;

            //    case "3":
            //        Debug.WriteLine("It is 3");
            //        break;

            //    default:
            //        Debug.WriteLine("Nothing");
            //        break;
            //}
            //Debug.WriteLine(str);
        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            folderPath=folderText.Text;
            Images.Clear();
            ImageGridView.ItemsSource = null;
            GetItemsAsync();
        }
    }
}
