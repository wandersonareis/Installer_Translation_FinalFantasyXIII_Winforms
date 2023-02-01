namespace LightningReturnFFXIII_pt_BR.Common;

public static class IDictionaryExm
{
    public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
    {
        return dic.TryGetValue(key, out TValue value) ? value : default;
    }
    public static bool SafeValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
    {
        return dic.TryGetValue(key, out _);
    }
}
