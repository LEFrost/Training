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
    /// StuLogin.xaml 的交互逻辑
    /// </summary>
    public partial class StuLogin : Window
    {
        public StuLogin()
        {
            InitializeComponent();
        }
        private LoginViewModel _ViewModel;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _ViewModel = new LoginViewModel();
            if (_ViewModel.Login(new Models.studentinfo()
            {
                stu_id = UserName.Text,
                stu_pwd = Password.Password
            }))
            {
                App.ID = UserName.Text;
                new StuWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("请确保密码和账号正确", "登陆失败");
            }
        }
    }
}
