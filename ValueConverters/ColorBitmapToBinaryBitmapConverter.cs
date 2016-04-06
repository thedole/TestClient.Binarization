using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using dok.image.binarization.win;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;

namespace TestClient.Binarization.ValueConverters
{
    public class ColorBitmapToBinaryBitmapConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceBitmap = value as BitmapImage;
            if (sourceBitmap == null)
            {
                return null;
            }

            var outputBitmap = sourceBitmap.Binarize(size: 20, k: 0.1);
            return outputBitmap.ToBitmapImage();
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ColorBitmapToBinaryBitmapConverter can only be used for one way conversion.");

        }
    }
}
