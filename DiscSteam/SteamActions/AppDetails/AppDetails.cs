using DiscSteam.config;
using DiscSteam.SteamActions.GetGamesFromFamily.Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace DiscSteam.SteamActions.GetGamesFromFamily
{
    public class AppDetails : SteamActionsBase
    {
        public async Task<List<Dictionary<int, AppDetailsResponse>>> GetHeaderImageAppdetails(List<int> ids)
        {
            var configs = new ReaderJSON();
            await configs.ReadConfigs();

            var headersImages = new List<Dictionary<int, AppDetailsResponse>>();
            using (var client = new HttpClient())
            {
                foreach (var id in ids)
                {
                    var uriText = CreateStoreURIBase(SteamActionsConstantsEndpoints.Appdetails);
                    var endpoint = new Uri(uriText + $"?appids={id}&filters=basic");
                    var result = await client.GetAsync(endpoint);
                    var json = await result.Content.ReadAsStringAsync();
                    var apps = JsonConvert.DeserializeObject<Dictionary<int, AppDetailsResponse>>(json);

                    if (result.IsSuccessStatusCode)
                    {
                        headersImages.Add(apps);
                    }
                }

                return headersImages;

            }
            return null;
        }
    }
}
