using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        //_modelBusinessRules.CheckIfModelNameLengthIsValid(request.Name);
        //_modelBusinessRules.CheckIfModelPriceIsValid(request.DailyPrice);
        //_modelBusinessRules.CheckIfModelYearIsValid(request.Year);

        if (request.Name.Length < 2)
            throw new Exception("model name length must be at least 2 characters.");
        if (request.Name.Length > 50)
            throw new Exception("Model name cannot be longer than 50 characters.");
        if (request.DailyPrice > 0)
            throw new Exception("Model daily price must be bigger than 0.");
        //TODO: fluent validation ile buradan ayrıştır.

        Model modelToAdd = _mapper.Map<Model>(request);

        _modelDal.Add(modelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        //business rules

        //data access

        //bool predicate(Model model)
        //{
        //    return (request.BrandId == null || model.BrandId == request.BrandId)
        //        && (request.FuelId == null || model.FuelId == request.FuelId)
        //        && (request.TransmissionId == null || model.TransmissionId == request.TransmissionId);
        //}
        //IList<Model> modelList = _modelDal.GetList(predicate);
        IList<Model> modelList = _modelDal.GetList(
            predicate: model =>
                (request.BrandId == null || model.BrandId == request.BrandId)
                && (request.FuelId == null || model.FuelId == request.FuelId)
                && (request.TransmissionId == null || model.TransmissionId == request.TransmissionId)
        );

        //mapping

        GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList);
        return response;
    }
}
