namespace LightningReturnFFXIII_pt_BR.Classes;

internal sealed record UpdateChecker
{
    private readonly Helper _helper;
    private string _appUpdateMessage = Resources.AppUpdateMessage;
    private string _translateUpdateMessage = Resources.TranslationUpdateMessage;
    public UpdateChecker(Helper helper)
    {
        _helper = helper;
    }

    public async ValueTask CheckUpdate()
    {
        JsonFromServer jsonFromServer = await _helper.FromJson();
        await CheckUpdate(jsonFromServer);
    }

    public async ValueTask CheckUpdate(JsonFromServer gitJson)
    {
        if (!string.IsNullOrEmpty(gitJson.TranslationChangelog))
            _translateUpdateMessage = $"{_translateUpdateMessage}\n\nAté agora:\n{gitJson.TranslationChangelog}";

        if (!_helper.CheckVersion(gitJson.AppVersion))
        {
            DialogResult confirm = MessageBox.Show(_appUpdateMessage, _helper.MessageTitle, MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await _helper.CheckApp(gitJson);
                return;
            }
        }

        if (!_helper.CompareToFileId(gitJson.TranslationId) || !_helper.CompareToFileHash(gitJson.Hash))
        {
            DialogResult confirm =
                MessageBox.Show(_translateUpdateMessage, _helper.MessageTitle, MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await _helper.CheckTranslation(gitJson);
            }
        }

        if (!string.IsNullOrEmpty(gitJson.AppChangelog))
            _appUpdateMessage = $"{_appUpdateMessage}\n\nChangelog:\n{gitJson.AppChangelog}";

    }
}