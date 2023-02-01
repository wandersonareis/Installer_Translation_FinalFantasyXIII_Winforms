
namespace LightningReturnFFXIII_pt_BR.Common
{
    internal static class ConvertersExt
    {
        public static string ConvertFromUnixTimestamp(this long timestamp, string format = "dd-MM-yyyy")
        {
            DateTime origin = new(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp).ToLocalTime().ToString(format);
        }
    }
}
