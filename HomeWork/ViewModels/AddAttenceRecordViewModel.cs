using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class AddAttenceRecordViewModel : BaseViewModel
    {
        private ObservableCollection<classinfo> _ClassNumList;
        private ObservableCollection<studentinfo> _StudentList;
        private ObservableCollection<string> _AttenceList;
        public ObservableCollection<studentinfo> StudentList { get => _StudentList ?? (_StudentList = new ObservableCollection<studentinfo>()); set => _StudentList = value; }
        public ObservableCollection<classinfo> ClassNumList { get => _ClassNumList ?? (_ClassNumList = new ObservableCollection<classinfo>()); set => _ClassNumList = value; }
        public ObservableCollection<string> AttenceList { get => _AttenceList ?? (_AttenceList = new ObservableCollection<string>()); set => _AttenceList = value; }
        public AddAttenceRecordViewModel()
        {
            AttenceList.Add("0");
            AttenceList.Add("1");
            AttenceList.Add("2");
            AttenceList.Add("4");

        }
        public void GetStuList(string classId)
        {
            StudentList.Clear();
            var query1 = from q in DBContext.studentinfo
                         join p in DBContext.selectcourse
                         on q.stu_id equals p.stu_id
                         where p.class_id == classId
                         select q;
            foreach (var item in query1)
            {
                StudentList.Add(item);
            }
        }
        public void GetData()
        {
            var query = from q in DBContext.classinfo
                        where q.teacher_id == App.ID
                        select q;
            foreach (var item in query)
            {
                ClassNumList.Add(item);

            }
            //var query1 = from q in DBContext.studentinfo
            //             select q;
            //foreach(var item in query1)
            //{
            //    StudentList.Add(item);
            //}
        }
        public bool InsertRecord(string classId, string stuId, string status, string date)
        {
            var query = DBContext.selectcourse.SingleOrDefault(x => x.class_id == classId && x.stu_id == stuId);
            if (query != null)
            {
                string selId = query.selectcourse_id;
                Guid guid = Guid.NewGuid();
                attendanceinfo temp = new attendanceinfo()
                {
                    selectcourse_id = selId,
                    att_id = guid.ToString(),
                    recordtime = date,
                    recordstatus = int.Parse (status)
                };
                DBContext.attendanceinfo.Add(temp);
                try
                {
                    //DBContext.Configuration.ValidateOnSaveEnabled = false;
                    DBContext.SaveChanges();
                    DBContext.Configuration.ValidateOnSaveEnabled = true;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
