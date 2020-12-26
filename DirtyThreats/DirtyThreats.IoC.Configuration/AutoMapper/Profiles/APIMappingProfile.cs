using AutoMapper;
using DC = DirtyThreats.API.DataContracts;
using S = DirtyThreats.Services.Model;

namespace DirtyThreats.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.UrlCheck, S.UrlCheck>().ReverseMap();
            CreateMap<DC.CheckResult, S.CheckResult>().ReverseMap();
        }
    }
}
