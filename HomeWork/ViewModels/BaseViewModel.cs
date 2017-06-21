using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        private StuAttendance _DBContext;
        public StuAttendance DBContext
        {
            get { return _DBContext ?? (_DBContext = new StuAttendance()); }
            set { _DBContext = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
