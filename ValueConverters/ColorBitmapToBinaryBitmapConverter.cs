using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using dok.image.binarization.win;

namespace TestClient.Binarization.ValueConverters
{
    public class ColorBitmapToBinaryBitmapConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceBitmap = value as BitmapSource;
            if (sourceBitmap == null)
            {
                return null;
            }

            //var binaryBitmap = sourceBitmap.Binarize(size: 20, k: 0.1);
            //return binaryBitmap.ToBitmapSource();

            var outputBitmapSource = sourceBitmap.FindAndShowRegionOfInterest(sourceBitmap);

            return outputBitmapSource;
        }        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ColorBitmapToBinaryBitmapConverter can only be used for one way conversion.");

        }
    }
}
