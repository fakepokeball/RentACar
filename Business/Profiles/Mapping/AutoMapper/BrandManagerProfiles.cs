using AutoMapper;
using Business.Dtos.Brand;
using Business.Requests.Brand;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class BrandManagerProfiles : Profile
{
    public BrandManagerProfiles()
    {
        CreateMap<AddBrandRequest, Brand>();
        CreateMap<Brand, AddBrandRequest>();

        CreateMap<Brand, BrandListItemDto>();
        CreateMap<IList<Brand>, GetBrandListResponse>()
            .ForMember(destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );
    }
}
