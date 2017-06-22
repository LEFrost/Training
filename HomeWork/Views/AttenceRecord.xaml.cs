using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// AttenceRecord.xaml 的交互逻辑
    /// </summary>
    public partial class AttenceRecord
    {
        private AddAttenceRecordViewModel _ViewModel;
        Timer timer = new Timer();
        public AttenceRecord()
        {
            InitializeComponent();
            timer.Interval = 100;
            //timer.Elapsed += Timer_Elapsed;
            ViewModel.GetData();
            RecordTime.Text = DateTime.Now.Date.GetDateTimeFormats('D')[0].ToString();
            timer.Start();
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        RecordTime.Text = DateTime.Now.ToString();
        //    });
        //}

        public AddAttenceRecordViewModel ViewModel { get => _ViewModel ?? (_ViewModel = new AddAttenceRecordViewModel()); set => _ViewModel = value; }

        private void ClassNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ClassNum.SelectedIndex;
            ClassName.Text = ViewModel.ClassNumList[index].course_name;
            ViewModel.GetStuList(ViewModel.ClassNumList[index].class_id);
        }

        private void StuID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = StuID.SelectedIndex;
            StuName.Text = ViewModel.StudentList[index].stu_name;
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            string classId, stuId, status;
            if (ClassNum.SelectedIndex < 0 || StuID.SelectedIndex < 0 || RecordStatu.SelectedIndex < 0)
                MessageBox.Show("请选择所有信息", "错误");
            else
            {
                classId = ViewModel.ClassNumList[ClassNum.SelectedIndex].class_id;
                stuId = ViewModel.StudentList[StuID.SelectedIndex].stu_id;
                status = ViewModel.AttenceList[RecordStatu.SelectedIndex];
                if (ViewModel.InsertRecord(classId, stuId, status, RecordTime.Text))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败", "错误");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
