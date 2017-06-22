using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork.Views
{
    /// <summary>
    /// StuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StuWindow
    {
        private MainViewModel _ViewModel;
        public MainViewModel ViewModel { get => _ViewModel ?? (_ViewModel = new MainViewModel()); set => _ViewModel = value; }

        public StuWindow()
        {
            InitializeComponent();
            ViewModel.GetInfo();
        }
        private void ShowWindow(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();

        }
        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new InfoWindow("学生个人信息"));
        }

        private void ModifyPassword_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new ModifyPassword());
        }

        private void ModifyInfo_Click(object sender, RoutedEventArgs e)
        {
            ModifyInfo window = new ModifyInfo();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (window.ShowDialog().HasValue)
            {
                ViewModel.GetInfo();
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (CourseId.Text != null)
            {
                if (!ViewModel.FindRecord(CourseId.Text))
                    MessageBox.Show("没有关于这个课的信息", "信息");

            }
            else
            {
                MessageBox.Show("请输入查找课程号", "错误");
            }
        }

        private void ShowTeacher_Click(object sender, RoutedEventArgs e)
        {
            ShowTeacherInfo window = new ShowTeacherInfo();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void ShowClass_Click(object sender, RoutedEventArgs e)
        {
            ShowCourseInfo window = new ShowCourseInfo();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
    }
}
