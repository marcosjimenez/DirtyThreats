using DirtyThreats.Services.Contracts;
using DirtyThreats.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirtyThreats.Services
{
    public class UrlCheckService : IUrlCheckService
    {

        private readonly IPluginService _pluginService;
        public UrlCheckService(IPluginService pluginService)
        {
            _pluginService = pluginService;
        }

        public async Task<UrlCheck> GetAsync(string url)
        {
            var retVal = new UrlCheck { Url = url };

            foreach (var plugin in _pluginService.GetPlugins())
            {
                if (await plugin.CheckIntegrity())
                {
                    var checkResult = new CheckResult
                    {
                        SourceName = plugin.Name,
                        Messages = new List<string>()
                    };

                    try
                    {
                        var result = await plugin.CheckUrl(url);
                        checkResult.Messages.AddRange(result.Messages);
                        checkResult.Positives = result.Positives;
                        checkResult.CheckCount = result.CheckCount;
                    }
                    catch (Exception ex)
                    {
                        checkResult.Messages.Add(ex.Message);
                    }

                    retVal.Sources = new List<CheckResult> { checkResult };
                }
            }

            return retVal;
        }
    }
}
