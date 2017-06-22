using HomeWork.Models;
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
using MahApps.Metro.Controls;

namespace HomeWork.Views
{
    /// <summary>
    /// TeacherLogin.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherLogin
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }
        private LoginViewModel _ViewModel;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            App.IsStu = false;

            _ViewModel = new LoginViewModel();
            teacherinfo teacher = new teacherinfo()
            {
                teacher_id = UserName.Text,
                teacher_pwd = Password.Password
            };
            if (_ViewModel.Login(teacher))
            {
                App.ID = UserName.Text;
                //App.IsAdmin = IsAdmin.IsChecked.HasValue;
                TeacherWindow window = new TeacherWindow();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("请确保密码和账号正确", "登陆失败");
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            UserName.Text =
                Password.Password = "";
            //IsAdmin.IsChecked = false;
        }
    }
}
