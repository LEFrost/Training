using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class ModifyRecordViewModel : BaseViewModel
    {
        private ObservableCollection<string> _StatusList;
        private ObservableCollection<StuAttence> _AttenceList;

        public ObservableCollection<StuAttence> AttenceList { get => _AttenceList ?? (_AttenceList = new ObservableCollection<StuAttence>()); set => _AttenceList = value; }
        public ObservableCollection<string> StatusList { get => _StatusList ?? (_StatusList = new ObservableCollection<string>()); set => _StatusList = value; }
        public bool CommitData()
        {
            try
            {
                //int i = 0;
                //var query1 = from n in (from q in DBContext.selectcourse
                //                        join p in DBContext.studentinfo
                //                        on q.stu_id equals p.stu_id
                //                        select new { stuid = q.stu_id, selid = q.selectcourse_id })
                //             join m in AttenceList
                //             on n.stuid equals m.StuId
                //             select new { n.stuid, n.selid, m.AttStatus };
                var query = from n in AttenceList
                            join m in DBContext.selectcourse
                            on n.StuId equals m.stu_id
                            select new { m.stu_id, m.selectcourse_id, n.AttStatus };
                var list = query.ToList();
                var query1 = from q in DBContext.attendanceinfo
                             select q;
                foreach (var item in query1)
                {
                    //var result = query.SingleOrDefault(x => x.selectcourse_id == item.selectcourse_id);
                    foreach (var item1 in list)
                    {
                        if (item1.selectcourse_id == item.selectcourse_id)
                            item.recordstatus = Convert.ToInt32(item1.AttStatus);
                    }

                }

                //foreach()

                DBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //private IQueryable<StuAttence> queryList = null;
        public void ShowData()
        {
            var queryList = from i in (from n in (from a in (from q in DBContext.classinfo
                                                             where q.teacher_id == App.ID
                                                             select q)
                                                  join b in DBContext.selectcourse
                                                  on a.class_id equals b.class_id
                                                  select new { courseName = a.course_name, stuId = b.stu_id, courseId = b.class_id, selectId = b.selectcourse_id })
                                       join m in DBContext.attendanceinfo
                                       on n.selectId equals m.selectcourse_id
                                       select new { courseName = n.courseName, selectId = n.selectId, courseId = n.courseId, stuId = n.stuId, status = m.recordstatus, time = m.recordtime })
                            join j in DBContext.studentinfo
                            on i.stuId equals j.stu_id
                            select new StuAttence()
                            {
                                CourseName = i.courseName,
                                CourseNum = i.courseId,
                                AttStatus = i.status.ToString(),
                                AttTime = i.time,
                                StuId = i.stuId,
                                StuName = j.stu_name
                            };
            if (queryList != null)
            {
                foreach (var item in queryList.Distinct())
                {
                    AttenceList.Add(item);
                }
            }
        }
    }
    public class StuAttence
    {
        private string _CourseNum;
        private string _CourseName;
        private string _StuId;
        private string _StuName;
        private string _AttTime;
        private string _AttStatus;

        public string CourseNum { get => _CourseNum; set => _CourseNum = value; }
        public string CourseName { get => _CourseName; set => _CourseName = value; }
        public string StuId { get => _StuId; set => _StuId = value; }
        public string StuName { get => _StuName; set => _StuName = value; }
        public string AttTime { get => _AttTime; set => _AttTime = value; }
        public string AttStatus { get => _AttStatus; set => _AttStatus = value; }
    }
}
