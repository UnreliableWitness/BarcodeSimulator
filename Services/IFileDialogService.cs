namespace BarcodeSimulator.Ui.Services
{
    public interface IFileDialogService
    {
        string LoadFileDialog(string fileName, string defaultExt, string filter);

        string SaveFileDialog(string fileName, string defaultExt, string filter);
    }
}
