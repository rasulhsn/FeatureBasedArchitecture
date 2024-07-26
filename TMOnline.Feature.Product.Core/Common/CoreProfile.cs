using AutoMapper;
using TMOnline.Feature.Product.Core.Commands;
using ProductEntity = TMOnline.Shared.Entities.Product;


namespace TMOnline.Feature.Product.Core
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<AddProductCommand, ProductEntity>(MemberList.None)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TransactionYearId, opt => opt.MapFrom(src => src.TransactionYearId));
        }
    }
}
