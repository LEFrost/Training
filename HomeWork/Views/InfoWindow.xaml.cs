using HomeWork.Utils;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork.Views
{
    /// <summary>
    /// InfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InfoWindow : Window
    {
        private InfoViewModel _ViewModel;
        public InfoViewModel ViewModel
        {
            get
            {
                return _ViewModel ?? (_ViewModel = new InfoViewModel());
            }
            set
            {
                _ViewModel = value;
            }
        }
        private string _TitleString;
        public string TitleString
        {
            get
            {
                return _TitleString;
            }
            set
            {
                _TitleString = value;
            }
        }
        public InfoWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }
        public InfoWindow(string title) : this()
        {
            TitleString = title;

            if (App.IsStu)
            {
                Id.Text = "学生编号";
                Facutly.Text = "所属专业";
                ViewModel.StuInfo(App.ID);
            }
            else
                ViewModel.TeacherInfo(App.ID);
        }

        private void ModifyEmail_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ModifyPictrue_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择文件";
            dialog.Filter = "图片文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            string file = null;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = dialog.FileName;
            }
            ViewModel.Photo = file;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
