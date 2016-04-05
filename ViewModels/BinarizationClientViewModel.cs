using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace TestClient.Binarization.ViewModels
{
    public class BinarizationClientViewModel : DependencyObject
    {
        public ObservableCollection<string> ImagePaths
        {
            get;
            set;
        }
        
        public BinarizationClientViewModel(string path)
        {
            SetImageFolder(path);
        }

        public void SetImageFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    throw new ArgumentOutOfRangeException(nameof(path), path, "Folder does not exist");
                }
                if (ImagePaths == null)
                {
                    ImagePaths = new ObservableCollection<string>();
                }
                else
                {
                    ImagePaths.Clear();
                }

                foreach (var fileName in Directory.EnumerateFileSystemEntries(path))
                {
                    if (!File.Exists(fileName))
                    {
                        continue;
                    }

                    if (!IsRecognisedImageFile(fileName))
                    {
                        continue;
                    }

                    ImagePaths.Add(fileName);
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool IsRecognisedImageFile(string fileName)
        {
            string targetExtension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(targetExtension))
                return false;
            else
                targetExtension = "*" + targetExtension.ToLowerInvariant();

            List<string> recognisedImageExtensions = new List<string>();

            foreach (System.Drawing.Imaging.ImageCodecInfo imageCodec in System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders())
                recognisedImageExtensions.AddRange(imageCodec.FilenameExtension.ToLowerInvariant().Split(";".ToCharArray()));

            foreach (string extension in recognisedImageExtensions)
            {
                if (extension.Equals(targetExtension))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
