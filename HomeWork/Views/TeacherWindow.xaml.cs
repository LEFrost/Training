using HomeWork.ViewModels;
using MahApps.Metro.Controls;
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
    /// TeacherWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherWindow
    {
        private MainViewModel _ViewModel;
        public MainViewModel ViewModel
        {
            get
            {
                return _ViewModel ?? (_ViewModel = new MainViewModel());
            }
            set
            {
                _ViewModel = value;
            }
        }
        public TeacherWindow()
        {
            InitializeComponent();
            ViewModel.GetInfo();
            //ViewModel.FindRecord("222");
        }

        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow window = new InfoWindow("教师信息");
            window.Show();
        }
        private void ShowWindow(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();

        }
        private void ModifyPassword_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new Views.ModifyPassword());
        }

        private void ModifyInfo_Click(object sender, RoutedEventArgs e)
        {
            ModifyInfo window = new Views.ModifyInfo();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (window.ShowDialog().HasValue)
            {
                ViewModel.GetInfo();
            }
        }

        private void ShowStuInfo_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(  new ShowStuInfo());
        }

        private void RecordInfo_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new AttenceRecord());
        }

        private void ShowRecord_Click(object sender, RoutedEventArgs e)
        {
            //ShowWindow(new StuAttenceInfo());
            new StuLogin().Show();
        }

        private void ModifyRecord_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow( new ModifyRecord());
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (CourseId.Text != null)
            {
                string id = CourseId.Text;
                if (!ViewModel.FindRecord(id))
                    MessageBox.Show("没有关于这个课的信息", "信息");
               //var List= ViewModel.FindRecord(id);
            }
            else
            {
                MessageBox.Show("请输入要查询的课程号", "错误");
            }
        }
    }
}
