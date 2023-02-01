using System.Text.Json;

namespace LightningReturnFFXIII_pt_BR.Common.Downloader;

public sealed record PackageDownloader
{
    public async Task<JsonFromServer> GetFromJson(string uri)
    {
        try
        {
            var api = new ServerApi(uri);
            using HttpResponseMessage httpResponse = await api.GetHttpResponse();

            if (httpResponse.Content.Headers.ContentType?.MediaType != "application/json")
                throw new HttpRequestException("HTTP Response was invalid and cannot be deserialised.");

            Stream contentStream = await httpResponse.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<JsonFromServer>(contentStream);
        }

        catch (HttpRequestException ex)
        {
            MessageBox.Show(ex.Message);
            return new JsonFromServer("", "", "", "", "", "", "", "");
            //throw;
        }
    }

    public async Task DoUpdate(ProgressManager progress, string downloadUrl, string updateFile)
    {
        try
        {
            progress.Begin();

            var api = new ServerApi(downloadUrl);
            using HttpResponseMessage response = await api.GetHttpResponse();

            await using Stream remoteFileStream = response.Content.ReadAsStreamAsync().Result;

            await using Stream updateFileStream = File.Create(updateFile, 2 * 1024);

            if (response.Content.Headers.ContentLength != null)
            {
                long totalBytes = response.Content.Headers.ContentLength.Value;
                long byteWritten = 0;

                var buffer = new byte[32 * 1024];

                while (true)
                {
                    int readSize = remoteFileStream.Read(buffer);

                    if (readSize == 0)
                    {
                        break;
                    }

                    byteWritten += readSize;

                    progress.SetPercent((int)((double)byteWritten / totalBytes * 100));
                    await updateFileStream.WriteAsync(buffer.AsMemory(0, readSize));
                }
            }

            progress.Finish();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}