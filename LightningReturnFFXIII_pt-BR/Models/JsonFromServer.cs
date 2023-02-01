using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LightningReturnFFXIII_pt_BR.Models;

public readonly struct JsonFromServer
{
    public JsonFromServer(string translationId, string translationUrl, string translationChangelog, string appVersion,
        string appUrl, string updateUrl, string appChangelog, string hash)
    {
        TranslationId = translationId;
        TranslationUrl = translationUrl;
        TranslationChangelog = translationChangelog;
        AppVersion = appVersion;
        AppUrl = appUrl;
        UpdateUrl = updateUrl;
        AppChangelog = appChangelog;
        Hash = hash;
    }

    [Required]
    [JsonPropertyName("TranslationID")]
    public string TranslationId { get; init; }

    [Required] public string TranslationUrl { get; init; }
    public string TranslationChangelog { get; init; }

    [Required] public string AppVersion { get; init; }
    public string AppUrl { get; init; }

    [Required] public string UpdateUrl { get; init; }
    public string AppChangelog { get; init; }

    [Required] public string Hash { get; init; }
}