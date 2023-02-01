namespace LightningReturnFFXIII_pt_BR.Common;

public static class FileIoExt
{
    public static FileStream? TryOpen(this string sourcePath) => sourcePath.FileIsExists() ? File.OpenRead(sourcePath) : null;

    public static async Task CopyToAsync(this string source, string destination)
    {
        if (destination.FileIsExists()) return;

        await using FileStream fsIn = File.OpenRead(source);
        await using Stream fsOut = File.Create(destination);
        await FileIo.CopyFileAsync(fsIn, fsOut);
    }

    public static async Task CopyToAsync(this string source, string destination, string text, ProgressManager progress)
    {
        if (destination.FileIsExists()) return;

        await using FileStream fsIn = File.OpenRead(source);
        await using Stream fsOut = File.Create(destination);
        await FileIo.CopyFileAsync(fsIn, fsOut, text, progress);
    }
}