using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class ShowPeopleInfoViewModel : BaseViewModel
    {
        private ObservableCollection<studentinfo> _ResultStuList;
        private ObservableCollection<TeacherMsg> _ResultTeaList;
        public ObservableCollection<studentinfo> ResultStuList { get => _ResultStuList ?? (_ResultStuList = new ObservableCollection<studentinfo>()); set => _ResultStuList = value; }
        public ObservableCollection<TeacherMsg> ResultTeaList { get => _ResultTeaList ?? (_ResultTeaList = new ObservableCollection<TeacherMsg>()); set => _ResultTeaList = value; }
        public void ClearAll()
        {
            ResultStuList.Clear();
            ResultTeaList.Clear();
        }
        public bool FindStu(FindWay way, string key)
        {
            ResultStuList.Clear();
            IQueryable<studentinfo> query = null;
            switch (way)
            {
                case FindWay.Name:
                    query = DBContext.studentinfo.Where(x => x.stu_name.Contains(key));
                    break;
                case FindWay.Class:
                    query = from a in (from q in DBContext.selectcourse
                                       where q.class_id == key
                                       select new { id = q.stu_id })
                            join b in DBContext.studentinfo
                           on a.id equals b.stu_id
                            select b;
                    break;
                case FindWay.College:
                    query = DBContext.studentinfo.Where(x => x.faculty_name.Contains(key));
                    break;
                case FindWay.Num:
                    query = DBContext.studentinfo.Where(x => x.stu_id.Contains(key));
                    break;
                default:
                    return false;
            }
            if (query != null)
            {
                foreach (var item in query)
                    ResultStuList.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ShowTeacher()
        {
            ResultStuList.Clear();
            var query = from n in (from a in (from q in DBContext.selectcourse
                                              where q.stu_id == App.ID
                                              select new { classId = q.class_id })
                                   join b in DBContext.classinfo
                                   on a.classId equals b.class_id
                                   select new { id = b.teacher_id ,courseName=b.course_name})
                        join m in DBContext.teacherinfo
on n.id equals m.teacher_id
                        select new TeacherMsg()
                        {
                            Name=m.teacher_name,
                            Course=n.courseName,
                            College=m.college_name
                        };
            if (query != null)
            {
                foreach (var item in query)
                {
                    ResultTeaList.Add(item);
                }
                return true;

            }
            else
            {
                return false;
            }

        }
    }
    public enum FindWay
    {
        Name,
        Class,
        College,
        Num
    }
    public class TeacherMsg
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string College { get; set; }
    }
}
