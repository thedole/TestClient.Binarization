using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using dok.image.binarization.win;

namespace TestClient.Binarization.ValueConverters
{
    public class FindAndShowLogoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceBitmap = value as BitmapSource;
            if (sourceBitmap == null)
            {
                return null;
            }

            var path = Path.GetFullPath(@"D:\DEV\OCR\images\logos\posten_only_rotated_and_caged.png");
            var postenLogo = ImageUtilities.ReadImage(path, LoadMode.GrayScale);

            var outputBitmapSource = ImageUtilities.Match(postenLogo, sourceBitmap);

            return outputBitmapSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
