using Microsoft.UI;
using Microsoft.UI.Windowing;
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
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public ObservableCollection<Account> Accounts { get; set; } = new ObservableCollection<Account>()
        { 
            new Account(){ Name = "My main account 2", Balance = 1_000_000 },
            new Account(){ Name = "My other account", Balance = 1_000_000_000 },
            new Account(){ Name = "My savings account", Balance = 999_999_999 }
        };


        public Account Account { get; set; } = new Account() { Name = "My main account", Balance = 1_000_000_000 };

        public MainWindow()
        {
            this.InitializeComponent();

            var windowHandle = WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Title = "Finance";
            var iconPath = Path.Combine(Package.Current.InstalledLocation.Path, "Assets\\app_icon.ico");
            appWindow.SetIcon(iconPath);
        }
    }
}
