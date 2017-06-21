using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ResultModel> _TeacherResultList;
        private ObservableCollection<ResultModel> _StudentResultList;
        private string _Photo;
        public string Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<ResultModel> TeacherResultList { get => _TeacherResultList ?? (_TeacherResultList = new ObservableCollection<ResultModel>()); set => _TeacherResultList = value; }
        public ObservableCollection<ResultModel> StudentResultList { get => _StudentResultList??(_StudentResultList=new ObservableCollection<ResultModel>()); set => _StudentResultList = value; }

        public void GetInfo()
        {
            if (App.IsStu)
            {
                DBContext.Dispose();
                DBContext = new Models.StuAttendance();
                var query = DBContext.studentinfo.SingleOrDefault(x => x.stu_id == App.ID);
                Photo = Application.StartupPath + "\\images\\" + query.stu_photo;
                Name = query.stu_name;
            }
            else
            {
                DBContext.Dispose();
                DBContext = new Models.StuAttendance();
                var query = DBContext.teacherinfo.SingleOrDefault(x => x.teacher_id == App.ID);
                Photo = Application.StartupPath + "\\images\\" + query.teacher_photo;
                Name = query.teacher_name;
            }
        }
        public bool FindRecord(string courseId)
        {
            if (!App.IsStu)
            {

                var query = from n in (from a in (from q in DBContext.attendanceinfo
                                                  join p in DBContext.selectcourse
                                                  on q.selectcourse_id equals p.selectcourse_id
                                                  select new { classId = p.class_id, stuId = p.stu_id, time = q.recordtime, stauts = q.recordstatus })
                                       join b in DBContext.classinfo
               on a.classId equals b.class_id
                                       where a.classId == courseId
                                       select new { ClassName = b.course_name, stuId = a.stuId, time = a.time, status = a.stauts })
                            join m in DBContext.studentinfo
    on n.stuId equals m.stu_id
                            select new ResultModel { ClassName = n.ClassName, StuName = m.stu_name, Time = n.time, Status = n.status.ToString() };

                if (query != null)
                {
                    TeacherResultList.Clear();
                    foreach (var item in query)
                    {
                        TeacherResultList.Add(item);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var query = from n in (from a in (from q in DBContext.attendanceinfo
                                                  join p in DBContext.selectcourse
                                                  on q.selectcourse_id equals p.selectcourse_id
                                                  where p.stu_id == App.ID
                                                  select new { classId = p.class_id, stuId = p.stu_id, time = q.recordtime, status = q.recordstatus })
                                       join b in DBContext.classinfo on a.classId equals b.class_id
                                       where a.classId == courseId
                                       select new { ClassName = b.course_name, stuId = a.stuId, time = a.time, status = a.status })
                            join m in DBContext.studentinfo
on n.stuId equals m.stu_id
                            select new ResultModel { ClassName = n.ClassName, StuName = m.stu_name, Time = n.time, Status = n.status.ToString() };
                if(query!=null)
                {
                    StudentResultList.Clear();
                    foreach(var item in query)
                    {
                        StudentResultList.Add(item);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
          }
        }
    }
    public class ResultModel
    {
        public string ClassName { get; set; }
        public string StuName { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}
