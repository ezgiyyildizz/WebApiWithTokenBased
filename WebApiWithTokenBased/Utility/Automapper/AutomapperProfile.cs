using AutoMapper;
using WebApiWithTokenBased.Dto;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.Utility.Automapper
{
    // AutoMapper konfigürasyonunu içeren sınıf
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // DTO nesneleri ile model nesneleri arasında eşleştirmeleri tanımlama
            CreateMap<RegistrationDto, UserCredentials>();
            CreateMap<LoginDto, UserCredentials>();
        }
    }
}
