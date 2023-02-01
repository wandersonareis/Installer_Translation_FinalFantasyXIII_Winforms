using System.Diagnostics;
using LightningReturnFFXIII_pt_BR.Classes;
using LightningReturnFFXIII_pt_BR.Common.Json;

namespace LightningReturnFFXIII_pt_BR;

public partial class MainUi : Form
{
    private readonly CreditUi CreditForm;
    private readonly Helper _helper;
    public MainUi()
    {
        InitializeComponent();
        CreditForm = new CreditUi();
        lbVersion.Text = string.Format(Resources.AppVersionString, Application.ProductVersion);
        _helper = new Helper(new AppConfig(), new ProgressManager(saaProgressBar), new LogManager(listBoxLog));
    }

    #region FileDrop

    private void TextBoxGameLocation_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data == null) return;
        e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
    }
    private void TextBoxGameLocation_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data == null) return;
        if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
        var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
        textBoxGameLocation.Text = fileNames.FirstOrDefault();
    }

    private void LinkVHG_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        "https://forum.tribogamer.com/viewtopic.php?f=10&t=28936".OpenUrl();
    }

    #endregion

    #region game location

    private void BtnGameLocation_Click(object sender, EventArgs e)
    {
        if (_helper.InProgress)
        {
            MessageBox.Show(Resources.InProgressWarning, _helper.MessageTitle);
            return;
        }

        _helper.InProgress = true;
        string? folderPath = DialogManager.FolderBrowser(Resources.GameLocation);
        if (!string.IsNullOrEmpty(folderPath))
        {
            textBoxGameLocation.Text = folderPath;
            _helper.AppConfig.GameLocation = folderPath;
            try
            {
                JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
            }
            catch (Exception exception)
            {
                _helper.InProgress = false;
                listBoxLog.Items.AddRange(_helper.ExceptioHandler(exception));
            }
        }

        _helper.InProgress = false;
    }

    private void MainUI_Load(object sender, EventArgs e)
    {
        try
        {
            _helper.SetRightAppVersion(Process.GetCurrentProcess(), _helper.Log);

            if (!_helper.ConfigFile.FileIsExists())
            {
                Directory.CreateDirectory(@".\Config");
                JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
            }

            _helper.AppConfig = JsonHelper.DeserializeFromFile<AppConfig>(_helper.ConfigFile);
        }
        catch (Exception err)
        {
            _helper.Log.Push(err.ToString());
            MessageBox.Show(Resources.WriteFailed, $@"{_helper.MessageTitle} - {err.GetType().Name}");
        }

        try
        {
            if (_helper.AppConfig.GameLocation.DirectoryIsExists())
            {
                textBoxGameLocation.Text = _helper.AppConfig.GameLocation;
                return;
            }

            new SteamByReg(_helper).GetByReg();

            if (string.IsNullOrEmpty(_helper.AppConfig.GameLocation)) return;

            textBoxGameLocation.Text = _helper.AppConfig.GameLocation;
            JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
        }
        catch (Exception err)
        {
            MessageBox.Show(Resources.ReadFailed, $@"{_helper.MessageTitle} - {err.GetType().Name}");
        }
    }
    #endregion

    

    private async void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (_helper.InProgress)
        {
            MessageBox.Show(Resources.InProgressWarning, _helper.MessageTitle);
            return;
        }

        _helper.InProgress = true;
        listBoxLog.Items.Clear();
        try
        {
            var operation = new Operation(_helper);
            await operation.Update();
        }
        catch (HttpRequestException)
        {
            _helper.InProgress = false;
            listBoxLog.Items.Add($"{Resources.UpdateBroken}\r\n{Resources.HttpRequestBroken}");
        }
        catch (IOException ioException)
        {
            _helper.InProgress = false;
            listBoxLog.Items.AddRange(_helper.ExceptioHandler(ioException));
        }
        catch (Exception exception)
        {
            _helper.InProgress = false;
            listBoxLog.Items.AddRange(_helper.ExceptioHandler(exception));
        }
        finally
        {
            _helper.InProgress = false;
        }
    }

    private void BtnUninstall_Click(object sender, EventArgs e)
    {
        if (_helper.InProgress)
        {
            MessageBox.Show(Resources.InProgressWarning, _helper.MessageTitle);
        }
        else
        {
            if (_helper.CheckDirectory())
            {
                _helper.InProgress = true;

                void BackupProvider()
                {
                    try
                    {
                        var backupProvider = new BackupProvider(_helper);
                        backupProvider.Uninstall();
                    }
                    catch (Exception err)
                    {
                        _helper.InProgress = false;
                        MessageBox.Show(err.Message, _helper.MessageTitle);
                        _helper.Log.Push(Resources.UnistallBroken);
                    }
                }

                Task.Run(BackupProvider).GetAwaiter().OnCompleted(() => { _helper.InProgress = false; });
            }
            else
            {
                MessageBox.Show(Resources.LocationException, _helper.MessageTitle);
            }
        }
    }

    private async void BtnInstall_Click(object sender, EventArgs e)
    {
        if (_helper.InProgress)
        {
            MessageBox.Show(Resources.InProgressWarning, _helper.MessageTitle);
            return;
        }

        if (_helper.CheckDirectory())
        {
            _helper.InProgress = true;
            listBoxLog.Items.Clear();

            try
            {
                Installer installer = new(_helper);
                await installer.Install();
            }
            catch (Exception exception)
            {
                _helper.InProgress = false;
                listBoxLog.Items.AddRange(_helper.ExceptioHandler(exception));
                listBoxLog.Items.Add(Resources.InstallBroken);
            }

            _helper.InProgress = false;
        }
        else
        {
            MessageBox.Show(Resources.LocationException, _helper.MessageTitle);
        }
    }

    private void BtnCredit_Click(object sender, EventArgs e)
    {
        if (!CreditForm.Visible) CreditForm.Show();
    }

    #region Listbox

    private void ListBoxLog_MeasureItem(object sender, MeasureItemEventArgs e) => e.ItemHeight = (int)e.Graphics.MeasureString(listBoxLog.Items[e.Index].ToString(), listBoxLog.Font, listBoxLog.Width).Height;

    private void ListBoxLog_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Font == null || e.Index < 0) return;
        e.DrawBackground();
        e.DrawFocusRectangle();
        e.Graphics.DrawString(listBoxLog.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
    }

    #endregion

    private async void MainUI_Shown(object sender, EventArgs e)
    {
        try
        {
            var updateChecker = new UpdateChecker(_helper);
            await updateChecker.CheckUpdate();
        }
        catch (Exception)
        {
            listBoxLog.Items.Add($"{Resources.UpdateBroken}\r\n{Resources.HttpRequestBroken}");
        }
    }

    private void MainUi_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_helper.InProgress) return;

        DialogResult window = MessageBox.Show(Resources.CancelWarning, Resources.ConfirmAnswer,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        e.Cancel = window == DialogResult.No;
    }
}
