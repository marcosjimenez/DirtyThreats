using DirtyThreats.Services.Model;
using System;
using System.Collections.Generic;

namespace DirtyThreats.Services.Contracts
{
    public interface IPluginService
    {
        void LoadPlugins();
        IPlugin GetPlugin(string pluginId);
        IEnumerable<IPlugin> GetPlugins();
    }
}
