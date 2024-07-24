using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using static System.Net.WebRequestMethods;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NavWinUi3App
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            //contentFrame.Navigate(typeof(SamplePage1));
        }

        //private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        //{
        //    //if (args.IsSettingsInvoked is true)
        //    //{
        //    //    contentFrame.Navigate(typeof(SamplePage1));
        //    //    return;
        //    //}

        //    //if (args.InvokedItemContainer is NavigationViewItem item &&
        //    //    item.Tag is string itemTag &&
        //    //    Type.GetType(itemTag) is Type pageType)
        //    //{
        //    //    contentFrame.Navigate(pageType);
        //    //}

        //    contentFrame.Navigate(typeof(SamplePage1));
        //}

        private void NavigationMenu_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(MainPage1));
        }

        private void NavigationMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // Handle settings here
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "MainPage1":
                        contentFrame.Navigate(typeof(MainPage1));
                        break;
                    case "SamplePage2":
                        contentFrame.Navigate(typeof(SamplePage2));
                        break;
                    case "ListPage":
                        contentFrame.Navigate(typeof(ListPage));
                        break;

                }
            }
        }

        //private void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    myButton.Content = "Clicked";
        //}
        //C# code behind


    }
}
