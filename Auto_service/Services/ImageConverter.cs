using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Auto_service.Services
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string part = (string)value;
                string path = "";
                if (part.Contains("Клиенты"))
                {
                    path = @"..\..\Resources\" + part;
                }
                else path = part; 
                var bitmapImage = new BitmapImage();
                byte[] rawImageData = null;
                

                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    rawImageData = new byte[fs.Length];
                    int count = (int)fs.Length / 1024;
                    for (int i = 0; i < count; i++)
                        fs.Read(rawImageData, i * 1024, 1024);
                    int last = (int)(fs.Length - count * 1024);
                    fs.Read(rawImageData, count * 1024, last);
                }

                using (var stream = new MemoryStream(rawImageData))
                {

                    bitmapImage.BeginInit();
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;

                    bitmapImage.EndInit();
                }
                return bitmapImage;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
