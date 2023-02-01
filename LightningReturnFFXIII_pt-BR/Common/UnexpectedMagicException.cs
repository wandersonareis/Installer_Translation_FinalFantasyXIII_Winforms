namespace LightningReturnFFXIII_pt_BR.Common;

public class UnexpectedMagicException : Exception
{
    private readonly string _magic;
    private readonly string _magicNameof;

    public override string Message => $"{base.Message} for variable '{_magicNameof}': {_magic}";

    public UnexpectedMagicException(string message, int magic, string nameofMagic) : base(message)
    {
        _magic = $"{magic} (0x{magic:X})";
        _magicNameof = nameofMagic;
    }

    public UnexpectedMagicException(string message, long magic, string nameofMagic) : base(message)
    {
        _magic = $"{magic} (0x{magic:X})";
        _magicNameof = nameofMagic;
    }

    public UnexpectedMagicException(string message, string magic, string nameofMagic) : base(message)
    {
        _magic = magic;
        _magicNameof = nameofMagic;
    }
}