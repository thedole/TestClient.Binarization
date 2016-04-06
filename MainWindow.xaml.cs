using System.Windows;
using System.IO;
using TestClient.Binarization.ViewModels;
using Microsoft.WindowsAPICodePack.Dialogs;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using System.Windows.Media.Imaging;
using dok.image.binarization.win;

namespace TestClient.Binarization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BinarizationClientViewModel(AppSettings.Default.ImagesFolder);
        }
        
        public void SelectFolder(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select folder with images to process";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = AppSettings.Default.ImagesFolder;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = AppSettings.Default.ImagesFolder;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() != CommonFileDialogResult.Ok)
            {
                return;
            }

            var folder = dlg.FileName;
            AppSettings.Default.ImagesFolder = folder;
            (DataContext as BinarizationClientViewModel).SetImageFolder(folder);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AppSettings.Default.Save();
        }

        private void buttonSaveOutput_Click(object sender, RoutedEventArgs e)
        {
            (imageOutput.Source as BitmapSource).SaveToDisk();
        }
    }
}
