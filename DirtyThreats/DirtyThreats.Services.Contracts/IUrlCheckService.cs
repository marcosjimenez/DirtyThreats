using DirtyThreats.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyThreats.Services.Contracts
{
    public interface IUrlCheckService
    {

        Task<UrlCheck> GetAsync(string url);

    }
}
