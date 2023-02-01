namespace LightningReturnFFXIII_pt_BR.Common;

public static class DriveExt
{
    public static DriveInfo GetDriveInfo(this string? drive)
    {
        return Array.Find(DriveInfo.GetDrives(), d => d.Name == drive) ??
               throw new InvalidOperationException();
    }

    public static string SizeSuffix(this long value, int decimalPlaces = 2)
    {
        string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException(nameof(decimalPlaces)); }
        switch (value)
        {
            case < 0:
                return "-" + SizeSuffix(-value);
            case 0:
                return string.Format("{0:n" + decimalPlaces + "} B", 0);
        }

        // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
        int mag = (int)Math.Log(value, 1024);

        // 1L << (mag * 10) == 2 ^ (10 * mag) 
        // [i.e. the number of bytes in the unit corresponding to mag]
        decimal adjustedSize = (decimal)value / (1L << (mag * 10));

        // make adjustment when the value is large enough that
        // it would round up to 1000 or more
        if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
        {
            mag += 1;
            adjustedSize /= 1024;
        }

        return string.Format("{0:n" + decimalPlaces + "} {1}",
            adjustedSize,
            sizeSuffixes[mag]);
    }
}