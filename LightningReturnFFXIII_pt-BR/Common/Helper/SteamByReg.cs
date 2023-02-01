using System.Text.RegularExpressions;
using LightningReturnFFXIII_pt_BR.Common.Json;
using Microsoft.Win32;

namespace LightningReturnFFXIII_pt_BR.Common
{
    public struct SteamByReg
    {
        private string _steamPath = "";
        private string _gameLocation = "";
        private readonly Helper _helper;
        public SteamByReg(Helper helper)
        {
            _helper = helper;
        }
        public void GetByReg()
        {
            const string registryPath = @"SOFTWARE\Wow6432Node\Valve\Steam";
            _steamPath = Registry.LocalMachine.OpenSubKey(registryPath)?.GetValue("InstallPath")?.ToString() ?? throw new Exception();
            if (string.IsNullOrWhiteSpace(_steamPath)) return;

            _gameLocation = Path.Combine(_steamPath, "steamapps", "common", "LIGHTNING RETURNS FINAL FANTASY XIII");
            if (!_gameLocation.DirectoryIsExists() || !_helper.CheckDirectory(_gameLocation)) GetByLibrary();

            _helper.AppConfig.GameLocation = _gameLocation;
            JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
        }

        private void GetByLibrary()
        {
            if (_steamPath == null) return;

            string libraryFolders = Path.Combine(_steamPath, "steamapps", "libraryfolders.vdf");
            if (!libraryFolders.FileIsExists()) return;

            string libContent = File.ReadAllText(libraryFolders);
            MatchCollection result = Regex.Matches(libContent, "\"path\"(.+)\"(.+)\"", RegexOptions.IgnoreCase);
            for (var i = 0; i < result.Count; )
            {
                var steamGameInfo = Path.Combine(result[i].Groups[2].Value.Replace(@":\\", @":\"), "steamapps",
                    "appmanifest_345350.acf");

                _gameLocation = Path.Combine(
                    Path.GetDirectoryName(steamGameInfo) ?? throw new InvalidOperationException(),
                    "common", "LIGHTNING RETURNS FINAL FANTASY XIII");

                if (!_gameLocation.DirectoryIsExists() || !_helper.CheckDirectory(_gameLocation))
                    return;

                _helper.AppConfig.GameLocation = _gameLocation;
                JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
                break;
            }
        }
    }
}
