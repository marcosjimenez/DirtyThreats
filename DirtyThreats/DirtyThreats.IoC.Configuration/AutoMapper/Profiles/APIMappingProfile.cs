using AutoMapper;
using DC = DirtyThreats.API.DataContracts;
using S = DirtyThreats.Services.Model;

namespace DirtyThreats.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Address, S.Address>().ReverseMap();
        }
    }
}
