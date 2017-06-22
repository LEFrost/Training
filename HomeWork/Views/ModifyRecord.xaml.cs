using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// ModifyRecord.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyRecord
    {

        private ModifyRecordViewModel _ViewModel;

        public ModifyRecordViewModel ViewModel { get => _ViewModel??(_ViewModel=new ModifyRecordViewModel()); set => _ViewModel = value; }

        public ModifyRecord()
        {
            InitializeComponent();
            ViewModel.ShowData();
        }
        private void ModifyRecord_Click(object sender, RoutedEventArgs e)
        {
            //AttenceRecord.IsReadOnly = false;
            CommitRecord.Content = "提交考勤记录";
            CommitRecord.Click += CommitRecord_Click;
            CommitRecord.Click -= ModifyRecord_Click;
        }
        private void CommitRecord_Click(object sender, RoutedEventArgs e)
        {
            //AttenceRecord.IsReadOnly = true;
            //CommitRecord.Content = "修改考勤记录";
            ViewModel.CommitData();
            foreach (var item in ViewModel.AttenceList)
                Debug.WriteLine(item.AttStatus);
            //CommitRecord.Click += ModifyRecord_Click;
            //CommitRecord.Click -= CommitRecord_Click;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
