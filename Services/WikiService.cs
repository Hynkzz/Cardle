using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Cardle.Services;

public static class WikiService
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string> GetCarImageUrl(string brand, string model)
    {
        // 1. Deneme: Tam Ad + "car" (Örn: "Volkswagen Golf car")
        string url = await SearchWiki($"{brand} {model} car");
        if (!string.IsNullOrEmpty(url)) return url;

        // 2. Deneme: Sadece Marka + Model (Örn: "Volkswagen Golf")
        url = await SearchWiki($"{brand} {model}");
        if (!string.IsNullOrEmpty(url)) return url;

        // 3. Deneme: Marka + Model + "automobile" (Örn: "Volkswagen Golf automobile")
        url = await SearchWiki($"{brand} {model} automobile");
        if (!string.IsNullOrEmpty(url)) return url;
        
        return "";
    }

    private static async Task<string> SearchWiki(string query)
    {
        try
        {
            string searchUrl = $"https://en.wikipedia.org/w/api.php?action=opensearch&search={query}&limit=1&namespace=0&format=json";

            if (!client.DefaultRequestHeaders.Contains("User-Agent"))
                client.DefaultRequestHeaders.Add("User-Agent", "CardleGame/1.0");

            var searchResponse = await client.GetStringAsync(searchUrl);
            var searchJson = JArray.Parse(searchResponse);

            if (searchJson[3].HasValues)
            {
                string pageUrl = searchJson[3][0].ToString();
                string pageTitle = pageUrl.Split('/').Last();

                string imgApiUrl = $"https://en.wikipedia.org/w/api.php?action=query&titles={pageTitle}&prop=pageimages&format=json&pithumbsize=600";
                
                var imgResponse = await client.GetStringAsync(imgApiUrl);
                var imgJson = JObject.Parse(imgResponse);
                
                var pages = imgJson["query"]["pages"];
                var firstPage = pages.First.First;

                if (firstPage["thumbnail"] != null)
                {
                    return firstPage["thumbnail"]["source"].ToString();
                }
            }
        }
        catch
        {
            // Hata olursa sessizce geç
        }
        return "";
    }
}