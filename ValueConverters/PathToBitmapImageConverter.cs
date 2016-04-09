using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using dok.image.binarization.win;

namespace TestClient.Binarization.ValueConverters
{
    public class PathToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileName = value as string;
            if (fileName == null)
            {
                return null;
            }

            var path = Path.GetFullPath(fileName);

            var bitmapSource = ImageUtilities.ReadImage(path, LoadMode.AnyColor);

            return bitmapSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("PathToBitmapImageConverter can only be used for one way conversion.");
        }
    }
}
