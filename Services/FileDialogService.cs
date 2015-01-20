namespace BarcodeSimulator.Ui.Services
{
    public class FileDialogService : IFileDialogService
    {
        public string LoadFileDialog(string fileName, string defaultExt, string filter)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = fileName; // Default file name
            dlg.DefaultExt = defaultExt; // Default file extension
            dlg.Filter = filter; // Filter files by extension 

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                return dlg.FileName;
            }

            return null;
        }

        public string SaveFileDialog(string fileName, string defaultExt, string filter)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = fileName; // Default file name
            dlg.DefaultExt = defaultExt; // Default file extension
            dlg.Filter = filter; // Filter files by extension 

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                // Save document 
                return dlg.FileName;
            }
            return null;
        }
    }
}
