using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        _modelBusinessRules.CheckIfModelNameNotExists(request.Name);
        _modelBusinessRules.CheckIfModelNameLengthIsValid(request.Name);
        _modelBusinessRules.CheckIfModelPriceIsValid(request.DailyPrice);
        _modelBusinessRules.CheckIfModelYearIsValid(request.Year);

        Model modelToAdd = _mapper.Map<Model>(request);

        _modelDal.Add(modelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {

        IList<Model> modelList = _modelDal.GetList();

        GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList);
        return response;
    }
}
