namespace LightningReturnFFXIII_pt_BR.Common;

public static class Strings
{
    public static string ExtractingPackageFiles(int fileCount) => string.Create(null, stackalloc char[60],
        $"Extraindo os arquivos da tradução.\nTotal: {fileCount} arquivos.\n");
    }