namespace LightningReturnFFXIII_pt_BR.Common;

public static class DialogManager
{
    public static string? FolderBrowser(string? filename)
    {
        var folderBrowser = new OpenFileDialog
        {
            ValidateNames = false,
            CheckFileExists = false,
            CheckPathExists = true,
            FileName = filename
        };
        string? result = null;
        if (folderBrowser.ShowDialog() == DialogResult.OK)
        {
            result = Path.GetDirectoryName(folderBrowser.FileName);
        }
        return result;
    }
}