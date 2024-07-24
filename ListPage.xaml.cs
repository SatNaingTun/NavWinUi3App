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
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NavWinUi3App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        public ListPage()
        {
            this.InitializeComponent();

            //for (int i = 0; i < 10; ++i)
            //{
            //    ListItems.Add(new Item() { Key = $"key {i} {Guid.NewGuid()}", Value = $"value {i} {Guid.NewGuid()}" });
            //}
        }

        public List<Item> ListItems = new List<Item>();

        public void AddItem(string key,string value)
        {
            ListItems.Add(new Item { Key =key,Value=value});
        }

    }
    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
