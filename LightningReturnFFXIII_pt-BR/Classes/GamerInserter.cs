using System.Text;
using System.Text.RegularExpressions;
using CliWrap;

namespace LightningReturnFFXIII_pt_BR.Classes
{
    internal class GamerInserter : IDisposable
    {
        private readonly string _tempPath;
        private readonly Helper _helper;
        private readonly string _crypt;
        private readonly string _msvcp100;
        private readonly string _msvcr100;


        public GamerInserter(string tempPath, Helper helper)
        {
            _tempPath = tempPath;
            _helper = helper;
            _crypt = _helper.GameDataDir + @"\ffxiiicrypt.exe";
            _msvcp100 = _helper.GameDataDir + @"\msvcp100.dll";
            _msvcr100 = _helper.GameDataDir + @"\msvcr100.dll";
        }

        public async Task Insert(string filelist, string whiteFile, string folder)
        {
            var stdOutBuffer = new StringBuilder(7000);
            var stdErrBuffer = new StringBuilder();

            File.Copy(_tempPath + @"\ffxiiicrypt.exe", _crypt, true);
            File.Copy(_tempPath + @"\msvcp100.dll", _msvcp100, true);
            File.Copy(_tempPath + @"\msvcr100.dll", _msvcr100, true);


            _ = await Cli.Wrap(_tempPath + @"\ff13tool.exe")
                .WithArguments(args => args.Add("-i").Add("-all").Add("-ff133").Add(filelist).Add(whiteFile).Add(Path.Combine(_tempPath, folder)))
                .WithWorkingDirectory(_helper.GameDataDir)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync().ConfigureAwait(false);


            var stdOut = stdOutBuffer.ToString();
            var stdErr = stdErrBuffer.ToString();
            if (stdOutBuffer.Length == 0)
            {
                _helper.Log.Push($"Houve um erro inesperado no arquivo {filelist}".AsSpan());
                return;
            }

            string Imported(string number) => string.Create(null, stackalloc char[45],
                $"{number} arquivos importados em {filelist}.");
            string GetNumber()
            {
                foreach (ReadOnlySpan<char> line in stdOutBuffer.ToString().SplitLines())
                {
                    if (!line.StartsWith("Imported".AsSpan())) continue;
                    return Regex.Match(line.ToString(), @"\b(\d+)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled).Value;
                }
                return string.Empty;
            }
            _helper.Log.Push(Imported(GetNumber()));


            if (stdErrBuffer.Length > 0)
            {
                _helper.Log.Push(stdErr);
            }
        }

        public void Dispose()
        {
            if (File.Exists(_tempPath))
                File.Delete(_tempPath);
            if (_tempPath.DirectoryIsExists())
                Directory.Delete(_tempPath, true);
            if (_crypt.FileIsExists())
                File.Delete(_crypt);
            if (_msvcp100.FileIsExists())
                File.Delete(_msvcp100);
            if (_msvcr100.FileIsExists())
                File.Delete(_msvcr100);
        }
    }
}