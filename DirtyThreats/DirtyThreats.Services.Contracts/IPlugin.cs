using DirtyThreats.Services.Model;
using System;
using System.Threading.Tasks;

namespace DirtyThreats.Services.Contracts
{
    public interface IPlugin
    {
        string Id { get; }
        string Name { get; }
        Task Initialize();
        Task<bool> CheckIntegrity();
        Task<CheckResult> CheckUrl(string url);
    }
}