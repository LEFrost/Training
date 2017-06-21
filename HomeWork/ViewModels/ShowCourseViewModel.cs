using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class ShowCourseViewModel : BaseViewModel
    {
        private ObservableCollection<CourseInfo> _ClassList;

        public ObservableCollection<CourseInfo> ClassList { get => _ClassList ?? (_ClassList = new ObservableCollection<CourseInfo>()); set => _ClassList = value; }
        public void GetList()
        {
            var query = from q in DBContext.classinfo
                        join p in DBContext.teacherinfo
                        on q.teacher_id equals p.teacher_id
                        select new CourseInfo
                        {
                            CourseName = q.course_name,
                            StartTime = q.class_time,
                            CourseTeacher = p.teacher_name,
                            EndWeek = q.class_end_week.ToString()
                        };
            foreach (var item in query)
            {
                ClassList.Add(item);
            }
        }
    }
    public class CourseInfo
    {
        private string _CourseName;
        private string _StartTime;
        private string _CourseTeacher;
        private string _EndWeek;

        public string CourseName { get => _CourseName; set => _CourseName = value; }
        public string StartTime { get => _StartTime; set => _StartTime = value; }
        public string CourseTeacher { get => _CourseTeacher; set => _CourseTeacher = value; }
        public string EndWeek { get => _EndWeek; set => _EndWeek = value; }
    }
}
