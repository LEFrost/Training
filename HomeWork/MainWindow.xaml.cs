using HomeWork.Views;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");
  
        }
        private void StartWindow(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();
        }
        private void StartStudent_Click(object sender, RoutedEventArgs e)
        {
            App.IsStu = true;
            StartWindow(new StuLogin());
           
        }
     
        private void StartTeacher_Click(object sender, RoutedEventArgs e)
        {
            App.IsStu = false;
            StartWindow(new TeacherLogin());
        }
    }
}
