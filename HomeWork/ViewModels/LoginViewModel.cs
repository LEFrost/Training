using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool Login(teacherinfo teacher)
        {
            var query = from q in DBContext.teacherinfo
                        where q.teacher_id == teacher.teacher_id && q.teacher_pwd == teacher.teacher_pwd
                        select q;
                /*DBContext.teacherinfo.FirstOrDefault(x => x.teacher_id == teacher.teacher_id&&x.teacher_pwd==teacher.teacher_pwd);*/
            if (query != null)
                return true;
            else
                return false;
        }
        public bool Login(studentinfo student)
        {
            var query = DBContext.studentinfo.FirstOrDefault(x => x.stu_id == student.stu_id&&x.stu_pwd==student.stu_pwd);
            if (query != null)
                return true;
            else
                return false;
        }
    }
}
