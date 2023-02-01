using LightningReturnFFXIII_pt_BR.Common.Json;
using System.Diagnostics;
using System.Security.Cryptography;
using CliWrap;
using System.Text;
using LightningReturnFFXIII_pt_BR.Common.Downloader;

namespace LightningReturnFFXIII_pt_BR.Common;

public class Helper : Base
{
    public AppConfig AppConfig;
    public readonly ProgressManager Progress;
    public readonly LogManager Log;

    public Helper(AppConfig appConfig, ProgressManager progress, LogManager log)
    {
        AppConfig = appConfig;
        Progress = progress;
        Log = log;
        ConfigFile = Path.Combine(AppDirectory, "Config", "config.json");
        ResourcesFile = Path.Combine(AppDirectory, "Resources", "[tribogamer.com]_Lightning_Return_FF13.bin");
        _appUpdate = Path.Combine(AppDirectory, "LightningReturnFFXIII_PT-BR update.exe");
        _appBase = Path.Combine(AppDirectory, "LightningReturnFFXIII_PT-BR.exe");
    }

    public PackageDownloader DownloaderInstance => new ();
    public string GameDataDir => Path.Combine(AppConfig.GameLocation, DataDirectory);

    public readonly string ConfigFile;
    public readonly string ResourcesFile;
    private readonly string _appUpdate;
    private readonly string _appBase;

    internal async Task<JsonFromServer> FromJson() => await DownloaderInstance.GetFromJson(Uri);

    /// <summary>
    /// Get TranslationID from Config.txt
    /// </summary>
    /// <returns></returns>
    public string? GetTranslationId() => AppConfig.TranslationId;

    public string ReadFileId()
    {
        using FileStream stream = File.OpenRead(ResourcesFile);
        using BinaryReader br = new(stream);
        br.BaseStream.Position = 8;
        return br.ReadInt64().ToString();
    }

    public async Task CheckApp(JsonFromServer json)
    {
        await _appUpdate.DeleteEvenWhenUsedAsync();
        Log.Push(Resources.AppUpdate);
        await DownloaderInstance.DoUpdate(Progress, json.UpdateUrl, _appUpdate);
        Thread.Sleep(1000);
        Cli.Wrap(_appUpdate).ExecuteAsync().GetAwaiter();
        InProgress = false;
        Application.Exit();
    }

    public async Task CheckTranslation(JsonFromServer json)
    {
        if (ResourcesFile.FileIsExists() && CompareToFileHash(json.Hash) && CompareToFileId(json.TranslationId))
        {
            AppConfig.TranslationId = ReadFileId();
            JsonHelper.SerializeToFile(AppConfig, ConfigFile);
            return;
        }
        
        Log.Push(Resources.DownTranslation);

        _ = Directory.CreateDirectory(@".\Resources");
        await DownloaderInstance.DoUpdate(Progress, json.TranslationUrl, ResourcesFile);

        Log.Push(Resources.DownTranslationComplete);
        AppConfig.TranslationId = json.TranslationId;

        JsonHelper.SerializeToFile(AppConfig, ConfigFile);
    }

    public bool CheckDirectory(string root = "")
    {
        return !string.IsNullOrEmpty(AppConfig.GameLocation) && root.Length < 1
            ? File.Exists(Path.Combine(AppConfig.GameLocation, ExeFile))
            : File.Exists(Path.Combine(root, ExeFile));
    }
    /// <summary>
    /// Compare local package Id with server package Id
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if files equal
    /// False is files Id different</returns>
    public bool CompareToFileId(string value)
    {
        if (!ResourcesFile.FileIsExists()) return false;

        using FileStream? stream = ResourcesFile.TryOpen();

        if (stream is null) return false;
        {
            using BinaryReader br = new(stream);
            br.BaseStream.Position = 8;
            var fileId = br.ReadInt64().ToString();
            return fileId.Equals(value, StringComparison.OrdinalIgnoreCase);
        }
    }
    public bool CompareToFileHash(string hashSource)
    {
        if (!ResourcesFile.FileIsExists()) return false;

        using FileStream stream = File.OpenRead(ResourcesFile) ?? throw new ArgumentNullException(nameof(hashSource));

        return hashSource == CalcHash();

        string BytesToStrings(byte[] bytes)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));
            }

            return builder.ToString();
        }

        string CalcHash()
        {
            using var sha256 = SHA256.Create();
            {
                byte[] bytes = sha256.ComputeHash(stream);

                return BytesToStrings(bytes);
            }
        }
    }

    public object[] ExceptioHandler(Exception ex)
    {
        object[] result = {ex.GetType().Name, ex.Message};

        return result;
    }

    #region True App Running

    public void SetRightAppVersion(Process app, LogManager log)
    {
        if (app is null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        switch (app.ProcessName)
        {
            case InstallerUpdateName:
                var name = Process.GetProcessesByName(app.ProcessName).Select(pr => pr.Id == app.Id);
                if (name.Any())
                {
                    KillProcess(InstallerName);

                    File.Copy(_appUpdate, _appBase, true);
                    Process aProcess = new()
                    {
                        StartInfo = new ProcessStartInfo(_appBase)
                    };
                    aProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    aProcess.Start();
                    KillProcess(InstallerUpdateName);
                }
                break;
            case InstallerName:

                if (_appUpdate.FileIsExists())
                {
                    KillProcess(InstallerUpdateName);
                    _appUpdate.DeleteEvenWhenUsed();
                }
                break;
            default:
                log.Push("Aconteceu algo!\nAtualize manualmente.".AsSpan());
                break;
        }

    }
    static void KillProcess(string name)
    {
        Process.GetProcesses()
            .Where(pr => pr.ProcessName.ToLower() == name)
            .ToList()
            .ForEach(p => p.Kill());
    }

    #endregion
}