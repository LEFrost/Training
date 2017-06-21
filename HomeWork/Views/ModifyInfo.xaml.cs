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
    /// ModifyInfo.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyInfo : Window
    {
        private ModifyInfoViewModel _ViewModel;
        public ModifyInfoViewModel ViewModel
        {
            get
            {
                return _ViewModel ?? (_ViewModel = new ModifyInfoViewModel());
            }
            set
            {
                _ViewModel = value;
            }
        }
        public ModifyInfo()
        {
            InitializeComponent();
            if (App.IsStu)
            {
                FacutlyLabel.Text = "所属专业";
            }
            this.DataContext = ViewModel;
            FacutlyComboBox.ItemsSource = ViewModel.FacultyList;
            CollegeComboBox.ItemsSource = ViewModel.CollegeList;

            Tuple<int, int> result = ViewModel.GetData();
            FacutlyComboBox.SelectedIndex = result.Item2;
            CollegeComboBox.SelectedIndex = result.Item1;
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


        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            string college = CollegeComboBox.SelectedItem.ToString();
            string faculty = FacutlyComboBox.SelectedItem.ToString();
            if (!ViewModel.ModifyInfo(college, faculty))
                System.Windows.MessageBox.Show("修改失败", "错误",MessageBoxButton.OK);
            else
            {
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
