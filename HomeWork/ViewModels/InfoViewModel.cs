using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.ViewModels
{
    public class InfoViewModel : BaseViewModel
    {
        private string _Name;
        private string _ID;
        private string _College;
        private string _Facutly;
        private string _Email;
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
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string College
        {
            get => _College;
            set
            {
                _College = value;
                OnPropertyChanged(nameof(College));
            }
        }
        public string Facutly
        {
            get => _Facutly;
            set
            {
                _Facutly = value;
                OnPropertyChanged(nameof(Facutly));
            }
        }
        public string Email
        {
            get => _Email;
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public bool StuInfo(string id)
        {
            var result = DBContext.studentinfo.FirstOrDefault(x=>x.stu_id==id);
            if (result != null)
            {
                ID = result.stu_id;
                Name = result.stu_name;
                College = result.college_name;
                Facutly = result.faculty_name;
                Email = result.stu_email;
                Photo = Application.StartupPath + @"\images\" + result.stu_photo;
                return true;
            }
            return false;
        }
        public bool TeacherInfo(string id)
        {
            var result = DBContext.teacherinfo.FirstOrDefault(x=>x.teacher_id==id);
            if (result != null)
            {
                ID = result.teacher_id;
                Name = result.college_name;
                College = result.college_name;
                Facutly = result.faculty_name;
                Email = result.teacher_email;
                Photo = Application.StartupPath + @"\images\" + result.teacher_photo;
                return true;
            }
            return false;
        }
    }
}
