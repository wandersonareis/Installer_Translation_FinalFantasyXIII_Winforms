using System.Text;
using ZstdSharp;

namespace LightningReturnFFXIII_pt_BR.Classes
{
    public class PackageReader
    {
        private readonly Helper _helper;

        private const long Magic = 0x494949584646524c;

        public PackageReader(Helper helper)
        {
            _helper = helper;
        }


        public async Task<string> ReadPackage()
        {
            _helper.Progress.Begin();

            await using Stream stream = File.OpenRead(_helper.ResourcesFile);
            using BinaryReader br = new(stream);
            br.BaseStream.Seek(0, SeekOrigin.Begin);

            long magic = br.ReadInt64();
            string id = $"{br.ReadInt64()}";
            var fileId = _helper.GetTranslationId();

            if (magic != Magic)
            {
                _helper.Log.Push(Resources.WrongPackage);
                return string.Empty;
            }
            if (id != _helper.GetTranslationId())
            {
                _helper.Log.Push(Resources.ExtractPackageInterrupted);
                throw new InvalidOperationException();
            }

            int fileCount = br.ReadInt32();
            _helper.Log.Push(Strings.ExtractingPackageFiles(fileCount).AsSpan());
            double percent = 100.0 / fileCount;

            using var decompressor = new Decompressor();

            for (var i = 0; i < fileCount; i++)
            {
                int pathLen = br.ReadInt32();
                string pathName = Encoding.ASCII.GetString(br.ReadBytes(pathLen));
                int dataLen = br.ReadInt32();
                byte[] data = br.ReadBytes(dataLen);

                string newPath = Path.Combine(_helper.PatchDirectory, pathName);
                _ = Directory.CreateDirectory(Path.GetDirectoryName(newPath) ?? throw new InvalidOperationException());

                bool isCompressed = br.ReadBoolean();
                if (isCompressed)
                {
                    byte[] decompressedData = decompressor.Unwrap(data).ToArray();
                    await File.WriteAllBytesAsync(newPath, decompressedData);
                }
                else
                {
                    await File.WriteAllBytesAsync(Path.Combine(_helper.GameDataDir, pathName), data);
                }

                _helper.Progress.Increase(percent, @"Extraindo o pacote");
            }

            _helper.Progress.Finish();
            return _helper.PatchDirectory;
        }
    }
}
