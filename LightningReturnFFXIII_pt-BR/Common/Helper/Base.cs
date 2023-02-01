using System.Reflection;

namespace LightningReturnFFXIII_pt_BR.Common;

public abstract class Base
{
    internal readonly string MessageTitle = "Lightning Return FF13 pt-BR";

    public readonly string Uri = "https://api.npoint.io/b7fa9dd201b5e145b492";

    private protected readonly string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private protected const string InstallerName = "LightningReturnFFXIII_pt-BR";
    private protected const string InstallerUpdateName = "LightningReturnFFXIII_PT-BR update";
    private protected const string DataDirectory = @"weiss_data\sys";

    public string PatchDirectory { get; } = Path.GetTempPath() + Guid.NewGuid();

    public const string BackupDirectory = "Backup";
    protected const string ExeFile = "LRFF13.exe";

    public Queue<GameSysFiles> FilesQueue
    {
        get
        {
            var queue = new Queue<GameSysFiles>(4);
            queue.Enqueue(new GameSysFiles { FileList = "filelist2a.win32.bin", WhiteFile = "white_img2a.win32.bin", FileFolder = "white_img2a", Language = "inglês" });
            queue.Enqueue(new GameSysFiles { FileList = "filelista.win32.bin", WhiteFile = "white_imga.win32.bin", FileFolder = "white_imga", Language = "inglês" });
            queue.Enqueue(new GameSysFiles { FileList = "filelist2v.win32.bin", WhiteFile = "white_img2v.win32.bin", FileFolder = "white_img2a", Language = "japonês" });
            queue.Enqueue(new GameSysFiles { FileList = "filelistv.win32.bin", WhiteFile = "white_imgv.win32.bin", FileFolder = "white_imga", Language = "japonês" });

            return queue;
        }
    }

    public bool InProgress { get; set; }

    public bool CheckVersion(string version) => Assembly.GetExecutingAssembly().GetName().Version >= new Version(version);

    public void MoveFiles(string source, string des) => File.Move(source, des, true);

    protected void MoveDirectory(string source, string des)
    {
        if (!Directory.Exists(des)) Directory.CreateDirectory(des);
        string[] files = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string file in files)
        {
            if (File.Exists(Path.Combine(des, Path.GetFileName(file)))) File.Delete(Path.Combine(des, Path.GetFileName(file)));
            File.Move(file, Path.Combine(des, Path.GetFileName(file)));
        }
        string[] folders = Directory.GetDirectories(source);
        foreach (string folder in folders)
        {
            MoveDirectory(folder, Path.Combine(des, Path.GetFileName(folder)));
        }
    }
}