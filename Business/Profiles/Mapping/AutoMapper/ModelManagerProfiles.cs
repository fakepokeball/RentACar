using AutoMapper;
using Business.Dtos.Model;
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class ModelManagerProfiles : Profile
{
    public ModelManagerProfiles()
    {
        CreateMap<AddModelRequest, Model>();
        CreateMap<Model, AddModelRequest>();

        CreateMap<Model, ModelListItemDto>();
        CreateMap<IList<Model>, GetModelListResponse>()
            .ForMember(destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );
    }
}
