using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HomeWork.Converts
{

    public class RecordStatusConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           switch(value.ToString())
            {
                case "0":
                    return "正常";
                case "1":
                    return "迟到";
                case "2":
                    return "请假";
                //case "3":
                //    return "病假";
                default:
                    return "缺课";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((value as ComboBoxItem).Content)
            {
                case "正常":
                    return "0";
                case "迟到":
                    return "1";
                case "请假":
                    return "2";
                //case "3":
                //    return "病假";
                default:
                    return "4";
            }
        }
    }
}
