using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace DiscSteam.config
{
    internal class ReaderJSON
    {
        public string TokenBot { get; set; }

        public Channels Channels { get; set; }

        public string SteamKey { get; set; }

        public string AcessToken { get; set; }

        public long FamilyGroupId { get; set; }

        public long LastGameAdquiredTime { get; set; }

        public async Task ReadConfigs()
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.TokenBot = data.TokenBot;
                this.Channels = data.Channels;
                this.SteamKey = data.SteamKey;
                this.FamilyGroupId = data.FamilyGroupId;
                this.AcessToken = data.AcessToken;
                this.LastGameAdquiredTime = data.LastGameAdquiredTime;
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }

        public async Task SetLastGameAdquiredTime(long lastGameAdquiredTime)
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                data.LastGameAdquiredTime = lastGameAdquiredTime;
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }

        public async Task SetNewGamesOfFamilyChannelId(ulong newGamesOfFamilyChannelId)
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                data.Channels.NewGamesOfFamily = newGamesOfFamilyChannelId;
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }

        public async Task SetTokenBot(string tokenBot)
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                data.TokenBot = tokenBot;
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }

        public async Task SetSteamKey(string steamKey)
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                data.SteamKey = steamKey;
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }

        public async Task SetAcessToken(string acessToken)
        {
            JSONStructure data = null;

            using (StreamReader str = new StreamReader("../../config/config.json"))
            {
                string json = await str.ReadToEndAsync();

                data = JsonConvert.DeserializeObject<JSONStructure>(json);
            }

            using (StreamWriter str = new StreamWriter("../../config/config.json"))
            {
                data.AcessToken = acessToken;
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                await str.WriteAsync(updatedJson);
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string TokenBot { get; set; }


        public Channels Channels { get; set; }

        public string SteamKey { get; set; }

        public string AcessToken { get; set; }

        public long FamilyGroupId { get; set; }

        public long LastGameAdquiredTime { get; set; }
    }

    internal sealed class Channels
    {
        public ulong NewGamesOfFamily { get; set; }
    }
}
