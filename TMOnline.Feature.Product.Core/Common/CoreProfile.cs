using AutoMapper;

namespace TMOnline.Feature.Product.Core
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Commands.AddProductCommand, Shared.Entities.Product>(MemberList.None)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TransactionYearId, opt => opt.MapFrom(src => src.TransactionYearId));
        }
    }
}
