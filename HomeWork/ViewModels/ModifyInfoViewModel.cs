using HomeWork.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.ViewModels
{
    public class ModifyInfoViewModel : BaseViewModel
    {
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
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
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
        private ObservableCollection<string> _CollegeList;
        public ObservableCollection<string> CollegeList
        {
            get
            {
                return _CollegeList ?? (_CollegeList = new ObservableCollection<string>());
            }
            set
            {
                _CollegeList = value;
            }
        }

        public ObservableCollection<string> FacultyList { get => _FacultyList ?? (_FacultyList = new ObservableCollection<string>()); set => _FacultyList = value; }

        private ObservableCollection<string> _FacultyList;
        public Tuple<int,int> GetData()
        {
            string college, faculty;
            college = faculty = "";
            if (App.IsStu)
            {
                var query = DBContext.studentinfo.SingleOrDefault(x => x.stu_id == App.ID);
                if (query != null)
                {
                    Name = query.stu_name;
                    Email = query.stu_email;
                    Id = query.stu_id;
                    Photo = Application.StartupPath + "\\images\\" + query.stu_photo;
                    college = query.college_name;
                    faculty = query.faculty_name;
                    //return new Tuple<string, string>(query.college_name, query.faculty_name);
                }
            }
            else
            {
                var query = DBContext.teacherinfo.SingleOrDefault(x => x.teacher_id == App.ID);
                if (query != null)
                {
                    Name = query.teacher_name;
                    Email = query.teacher_email;
                    Id = query.teacher_id;
                    Photo = Application.StartupPath + "\\images\\" + query.teacher_photo;
                    college = query.college_name;
                    faculty = query.faculty_name;
                    //return new Tuple<string, string>(query.college_name, query.faculty_name);
                }
            }
            GetList();
            //CollegeList.IndexOf(college)
            //FacultyList.IndexOf(faculty)
            return new Tuple<int, int>(CollegeList.IndexOf(college), FacultyList.IndexOf(faculty));
        }
        public bool GetList()
        {
            var query = from q in DBContext.collegeinfo
                        select q;
            var query2 = from q in DBContext.facultyinfo
                         select q;
            if (query != null && query2 != null)
            {

                foreach (var item in query)
                {
                    CollegeList.Add(item.college_name);
                }
                foreach (var item in query2)
                {
                    FacultyList.Add(item.faculty_name);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ModifyInfo(string college, string faculty)
        {
            Guid guid = Guid.NewGuid();

            if (App.IsStu)
            {
                var query = DBContext.studentinfo.SingleOrDefault(x => x.stu_id == App.ID);
                if (query != null)
                {
                    string path = query.stu_photo;
                    string name = guid.ToString();
                    query.stu_photo = name+".jpg";
                    if (ImageUtil.WriteImage(Image.FromFile(Photo),name))
                    {
                        query.stu_email = Email;
                        try
                        {

                            DBContext.SaveChanges();
                          //  File.Delete(Application.StartupPath+"\\images\\"+ path);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                var query = DBContext.teacherinfo.SingleOrDefault(x => x.teacher_id == App.ID);
                if (query != null)
                {
                    string path = query.teacher_photo;
                    string name = guid.ToString();
                    query.teacher_photo =name+".jpg";
                    if (ImageUtil.WriteImage(Image.FromFile(Photo),name))
                    {
                        query.teacher_email = Email;
                        try
                        {

                            DBContext.SaveChanges();
                          //  File.Delete(Application.StartupPath + "\\images\\" + path);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
