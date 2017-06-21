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
    /// ModifyPassword.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPassword : Window
    {
        private ModifyPasswordViewModel _ViewModel;
        public ModifyPassword()
        {
            InitializeComponent();
            _ViewModel = new ModifyPasswordViewModel();

        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            if (NewPassword.Password != ConfirePassword.Password)
            {
                MessageBox.Show("请确保两次密码输入相同", "错误");
                return;
            }
            if(App.IsStu)
            {
               if( _ViewModel.ConfireStuPassword(App.ID, OldPassword.Password))
                {
                    if(_ViewModel.ModifyStuPassword(App.ID,NewPassword.Password))
                    {
                        if(MessageBox.Show("密码更改成功","消息",MessageBoxButton.OK)==MessageBoxResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

  
    }
}
