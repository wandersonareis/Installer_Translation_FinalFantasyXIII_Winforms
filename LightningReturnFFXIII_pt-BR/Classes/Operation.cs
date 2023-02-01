using LightningReturnFFXIII_pt_BR.Common.Json;

namespace LightningReturnFFXIII_pt_BR.Classes;

public class Operation
{
    private readonly Helper _helper;

    public Operation(Helper helper)
    {
        _helper = helper;
    }

    public async ValueTask Update()
    {
        _helper.Progress.Begin();
        _ = Directory.CreateDirectory(@".\Resources");

        _helper.Log.Push(Resources.Server_Response);

        JsonFromServer jsonFromServer = await _helper.FromJson();

        _helper.Log.Push(string.Format(Resources.AppVersion, jsonFromServer.AppVersion));
        _helper.Log.Push(string.Format(Resources.TranslationID, jsonFromServer.TranslationId));
        _helper.Log.Push(string.Format(Resources.TranslationTime, long.Parse(jsonFromServer.TranslationId).ConvertFromUnixTimestamp()));

        if (await CheckTranslation())
        {
            Installer installer = new(_helper);
            await installer.Install();
        }

        Task<bool> CheckTranslation()
        {
            while (true)
            {
                if (!_helper.ResourcesFile.FileIsExists() ||
                    !_helper.CompareToFileHash(jsonFromServer.Hash) ||
                    !_helper.CompareToFileId(jsonFromServer.TranslationId))
                {
                    return Task.FromResult(false);
                }

                _helper.AppConfig.TranslationId = _helper.ReadFileId();
                JsonHelper.SerializeToFile(_helper.AppConfig, _helper.ConfigFile);
                return Task.FromResult(true);
            }
        }
    }
}