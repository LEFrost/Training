using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ShowStuInfo.xaml 的交互逻辑
    /// </summary>
    public partial class ShowStuInfo
    {
        private ShowPeopleInfoViewModel _ViewModel;
        private ObservableCollection<string> _FindWayList;
        public ObservableCollection<string> FindWayList
        {
            get
            {
                return _FindWayList??(_FindWayList=new ObservableCollection<string>());
            }
            set
            {
                _FindWayList = value;
            }
        }

        public ShowPeopleInfoViewModel ViewModel { get => _ViewModel ?? (_ViewModel = new ShowPeopleInfoViewModel()); set => _ViewModel = value; }

        public ShowStuInfo()
        {
            InitializeComponent();
            FindWayList.Add("按名字查询");
            FindWayList.Add("按教学班查询");
            FindWayList.Add("按专业查询");
            FindWayList.Add("按学号查询");
            
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.FindStu((FindWay)FindWayComboBox.SelectedIndex, KeyInput.Text.Trim());
        }

        private void RestartFind_Click(object sender, RoutedEventArgs e)
        {
            FindWayComboBox.SelectedIndex = 0;
            KeyInput.Text = string.Empty;
            ViewModel.ClearAll();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
