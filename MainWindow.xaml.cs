using System.Windows;
using System.IO;
using TestClient.Binarization.ViewModels;
using Microsoft.WindowsAPICodePack.Dialogs;

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
            DataContext = new BinarizationClientViewModel(".");
        }
        
        public void SelectFolder(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select folder with images to process";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = Directory.GetCurrentDirectory();

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = Directory.GetCurrentDirectory();
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
            (DataContext as BinarizationClientViewModel).SetImageFolder(folder);
        }
    }
}
