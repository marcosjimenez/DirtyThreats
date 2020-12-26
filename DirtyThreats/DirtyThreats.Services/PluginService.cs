using AutoMapper;
using DirtyThreats.API.Common.Settings;
using DirtyThreats.Services.Contracts;
using DirtyThreats.Services.Model;
using DirtyThreats.Services.Plugins;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyThreats.Services
{
    public class PluginService : IPluginService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private List<IPlugin> _plugins;

        public PluginService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings.Value;
            _mapper = mapper;
            _plugins = new List<IPlugin> { new VirusTotalPlugin() };

            foreach (var item in _plugins)
                item.Initialize();
        }

        public void LoadPlugins()
        {
            //TODO: Runtime
        }

        public IPlugin GetPlugin(string pluginId)
        {
            return _plugins.Where(x => x.Id == pluginId).FirstOrDefault();
        }

        public IEnumerable<IPlugin> GetPlugins()
        {
            foreach (var item in _plugins)
                yield return item;
        }
    }
}
