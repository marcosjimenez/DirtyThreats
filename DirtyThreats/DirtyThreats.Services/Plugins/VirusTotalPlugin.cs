using DirtyThreats.Services.Contracts;
using DirtyThreats.Services.Model;
using System;
using Flurl;
using Flurl.Http;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DirtyThreats.Services.Plugins
{
    public class VirusTotalPlugin : IPlugin
    {
        private const string PluginId = "ce1b609c-30af-4aa2-87b9-1259179bf653";
        public string ConfigFile { get; set; } = @"D:\Code\VirusTotalPluginConfig.json";
        public VirusTotalPluginConfig Config { get; private set; }

        public string Id { get => PluginId; }
        public string Name { get => "VirusTotal Parser"; }

        public VirusTotalPlugin()
        {
            Config = new VirusTotalPluginConfig();
        }

        public async Task<bool> CheckIntegrity()
        {
            return !string.IsNullOrWhiteSpace(Config.ApiKey);
        }

        public async Task<CheckResult> CheckUrl(string url)
        {
            var retVal = new CheckResult
            {
                SourceName = "VirusTotal"
            };

            var result = await GetUrl("url", "report")
                .SetQueryParam("resource", url)
                .GetJsonAsync<VirusTotalUrlReportResult>();

            retVal.CheckCount = result.Total;
            retVal.Positives = result.Positives;
            retVal.Messages = new List<string> { $"Response code: {result.ResponseCode }",  result.VerboseMsg };

            return retVal;
        }

        public async Task Initialize()
        {
            if (!File.Exists(ConfigFile))
                throw new FileNotFoundException($"File {ConfigFile} not found!");

            string configContent = File.ReadAllText(ConfigFile);
            Config = JsonConvert.DeserializeObject<VirusTotalPluginConfig>(configContent);
        }

        private Url GetUrl (params string[] segments)
        {
            return Config.Url
                .AppendPathSegments(segments)
                .SetQueryParam("apikey", Config.ApiKey);
        }

    }
}
