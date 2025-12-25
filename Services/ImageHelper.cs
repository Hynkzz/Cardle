using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cardle.Services;

public static class ImageHelper
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string> DownloadAndSaveImage(
        string imageUrl,
        string brand,
        string model,
        string webRootPath)
    {
        if (string.IsNullOrEmpty(imageUrl))
            return "";

        try
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CardleGame/1.0");

            var bytes = await client.GetByteArrayAsync(imageUrl);

            var imagesDir = Path.Combine(webRootPath, "car-images");
            Directory.CreateDirectory(imagesDir);

            var ext = Path.GetExtension(imageUrl);
            if (string.IsNullOrEmpty(ext)) ext = ".jpg";

            var safeName = $"{brand}-{model}"
                .ToLower()
                .Replace(" ", "-")
                .Replace("/", "-");

            var filePath = Path.Combine(imagesDir, $"{safeName}{ext}");

            await File.WriteAllBytesAsync(filePath, bytes);

            // DB’ye gidecek yol
            return $"/car-images/{safeName}{ext}";
        }
        catch
        {
            return "";
        }
    }
}