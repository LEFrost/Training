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
    /// ShowTeacherInfo.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTeacherInfo : Window
    {
        private ShowPeopleInfoViewModel _ViewModel;
        public ShowPeopleInfoViewModel ViewModel { get => _ViewModel??(_ViewModel=new ShowPeopleInfoViewModel()); set => _ViewModel = value; }
        public ShowTeacherInfo()
        {
            InitializeComponent();
            ViewModel.ShowTeacher();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
