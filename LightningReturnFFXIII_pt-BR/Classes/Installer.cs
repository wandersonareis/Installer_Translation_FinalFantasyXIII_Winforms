namespace LightningReturnFFXIII_pt_BR.Classes;

public class Installer
{
    private readonly Helper _helper;

    public Installer(Helper helper)
    {
        _helper = helper;
    }
    public async Task Install()
    {
        if (string.IsNullOrEmpty(_helper.AppConfig.GameLocation))
        {
            _helper.Log.Push(Resources.GameDirectoryNot);
            return;
        }

        string totalSizeSuffix = Path.GetPathRoot(new FileInfo(_helper.AppConfig.GameLocation).FullName).GetDriveInfo().TotalFreeSpace.SizeSuffix();

        DialogResult confirm =
            MessageBox.Show(string.Format(Resources.FreeSpace, totalSizeSuffix), _helper.MessageTitle, MessageBoxButtons.YesNo);

        if (confirm == DialogResult.Yes)
        {
            _helper.Log.Clear();
            var backupProvider = new BackupProvider(_helper);
            await backupProvider.Backup();

            _helper.Log.Push(Resources.BeginInstall.AsSpan());
        }
        else
        {
            _helper.Log.Push(Resources.InstallCanceled);
            return;
        }


        if (!File.Exists(_helper.ResourcesFile)) throw new Exception(Resources.BinNotFounded);

        PackageReader packageHelper = new(_helper);
        string tempPackage = await packageHelper.ReadPackage();
        if (string.IsNullOrEmpty(tempPackage)) throw new DirectoryNotFoundException("Diretório de extração do pacote não encontrado!");

        _helper.Progress.Begin();
        using GamerInserter inserter = new(tempPackage, _helper);

        foreach (GameSysFiles gameSysFiles in _helper.FilesQueue)
        {
            await inserter.Insert(filelist: gameSysFiles.FileList, whiteFile: gameSysFiles.WhiteFile, folder: gameSysFiles.FileFolder).ConfigureAwait(false);
            _helper.Progress.PrgressOnlyText($"Inserindo arquivos em {gameSysFiles.FileList}");
        }

        _helper.Log.Push($"{Resources.InstallTranslationComplete} ✌✌✌");
    }
}