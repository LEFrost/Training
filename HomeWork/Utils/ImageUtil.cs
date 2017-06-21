using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace HomeWork.Utils
{
    public class ImageUtil
    {
        public static Image ReadImage(string path)
        {
            Image image = null;
            if (File.Exists(path))
            {
                image = Image.FromFile(path);
            }
            return image;
        }
        public static bool WriteImage(Image image,string name)
        {
            if(image!=null)
            {
                //File.Create("images/" + name+".jpg");
                string path = @"images/" + name+ ".jpg";
                image.Save(path,ImageFormat.Jpeg);
                return true;
            }
            return false;
        }
    }
}
