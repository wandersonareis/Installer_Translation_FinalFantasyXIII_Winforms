using System.Diagnostics;

namespace LightningReturnFFXIII_pt_BR.Common;

public static class Extensions
{
    public static void OpenUrl(this string uri)
    {
        try
        {
            ProcessStartInfo psi = new()
            {
                UseShellExecute = true,
                FileName = uri
            };
            _ = Process.Start(psi);
        }
        catch (System.ComponentModel.Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259)
                MessageBox.Show(noBrowser.Message);
        }
        catch (Exception other)
        {
            MessageBox.Show(other.Message);
        }
    }
}