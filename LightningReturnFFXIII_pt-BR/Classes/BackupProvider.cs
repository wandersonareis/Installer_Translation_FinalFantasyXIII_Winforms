namespace LightningReturnFFXIII_pt_BR.Classes;

public class BackupProvider
{
    private readonly Helper _helper;
    public BackupProvider(Helper helper)
    {
        _helper = helper;
    }
    public async Task Backup()
    {
        _helper.Progress.Begin();
        _helper.Log.Push(Resources.MakeBackup);
        string backupDir = Path.Combine(_helper.AppConfig.GameLocation, Base.BackupDirectory);
        if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);
        
        foreach (GameSysFiles queueDataFile in _helper.FilesQueue)
        {
            string sourceFileList = Path.Combine(_helper.GameDataDir, queueDataFile.FileList);
            string sourceWhiteFile = Path.Combine(_helper.GameDataDir, queueDataFile.WhiteFile);

            if (!sourceFileList.FileIsExists() || !sourceWhiteFile.FileIsExists())
            {
                _helper.Log.Push($"{queueDataFile} no idioma {queueDataFile.Language} não existe!");
                continue;
            }

            await sourceFileList.CopyToAsync(Path.Combine(backupDir, queueDataFile.FileList));
            await sourceWhiteFile.CopyToAsync(Path.Combine(backupDir, queueDataFile.WhiteFile), $"Fazendo backup de {queueDataFile.FileList}", _helper.Progress);
        }

        _helper.Progress.Finish();
    }
    public void Uninstall()
    {
        DialogResult confirm = MessageBox.Show(Resources.UninstallConfirm,
            _helper.MessageTitle, MessageBoxButtons.YesNo);
        if (confirm != DialogResult.Yes) return;

        _helper.Log.Clear();
        _helper.Progress.Begin();
        _helper.Log.Push(Resources.UninstallStart);
        string backupDir = Path.Combine(_helper.AppConfig.GameLocation, Base.BackupDirectory);

        double percent = 100.0 / _helper.FilesQueue.Count + 1;
        if (!_helper.GameDataDir.DirectoryIsExists() || !backupDir.DirectoryIsExists())
            throw new(Resources.UninstallFailed);
        
        foreach (GameSysFiles queueDataFile in _helper.FilesQueue)
        {
            string backupFileList = Path.Combine(backupDir, queueDataFile.FileList);
            string backupWhiteFile = Path.Combine(backupDir, queueDataFile.WhiteFile);

            if (!backupFileList.FileIsExists() && !backupWhiteFile.FileIsExists())
            {
                _helper.Log.Push($"{queueDataFile} no idioma {queueDataFile.Language} não existe!");
                continue;
            }

            _helper.MoveFiles(backupFileList, Path.Combine(_helper.GameDataDir, queueDataFile.FileList));
            _helper.MoveFiles(backupWhiteFile, Path.Combine(_helper.GameDataDir, queueDataFile.WhiteFile));
            _helper.Progress.Increase(percent, "Restaurando backup");
        }
        
        Directory.Delete(backupDir, true);
        _helper.Progress.Finish();
        _helper.Log.Push(Resources.UninstallComplete);
    }
}