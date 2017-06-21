using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class ModifyPasswordViewModel : BaseViewModel
    {
        public bool ConfireStuPassword(string id, string oldPassword)
        {
            var query = DBContext.studentinfo.SingleOrDefault(x => x.stu_id == id && x.stu_pwd == oldPassword);
            if (query == null)
                return false;
            else
            {
                return true;
            }
        }
        public bool ConfireTeacherPassword(string id, string oldPassword)
        {
            var query = DBContext.teacherinfo.SingleOrDefault(x => x.teacher_id == id && x.teacher_pwd == oldPassword);
            if (query == null)
                return false;
            else
            {
                return true;
            }
        }
        public bool ModifyStuPassword(string id, string newPassword)
        {
            var query = DBContext.studentinfo.SingleOrDefault(x => x.stu_id == id);
            if (query != null)
                query.stu_pwd = newPassword;
            else
                return false;
            try
            {
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModifyTeacherPassword(string id, string newPassword)
        {
            var query = DBContext.teacherinfo.SingleOrDefault(x => x.teacher_id == id);
            if (query != null)
                query.teacher_pwd = newPassword;
            else
                return false;
            try
            {
                DBContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
