using HomeWork.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    { 
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new HomeWork.MainWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
        public static bool IsAdmin { get; set; }
        public static bool IsStu { get; set; }
        public static string UserName { get; set; }
        public static string ID { get; set; }
    }
}
