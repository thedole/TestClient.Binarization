using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using dok.image.binarization.win;

namespace TestClient.Binarization.ValueConverters
{
    public class CropImageToRegionOfInterestConverter : IValueConverter
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

            var outputBitmapSource = sourceBitmap.CropToLargestContour();

            return outputBitmapSource;
        }

        public object ConvertBack(object value, Type targ5etType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("CropImageToRegionOfInterestConverter can only be used for one way conversion.");

        }
    }
}