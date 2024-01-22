using DataAccess.Abstract;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
    }

    public void CheckIfModelNameNotExists(string modelName)
    {
        bool isExists = _modelDal.GetList().Any(m => m.Name == modelName);
        if (isExists)
        {
            throw new Exception("Model already exists.");
        }
    }
    public void CheckIfModelNameLengthIsValid(string modelName)
    {
        if (modelName.Length<2)
        {
            throw new Exception("Model name length must be contains at least 2 characters.");
        }
    }
    public void CheckIfModelPriceIsValid(decimal modelDailyPrice)
    {
        if (modelDailyPrice==0 || modelDailyPrice<0)
        {
            throw new Exception("Model daily price must be bigger than 0");
        }
    }
    public void CheckIfModelYearIsValid(short year)
    {
        short thisYear = Convert.ToInt16(DateTime.Now.Year);
        if (year<(thisYear-20))
        {
            throw new Exception("Model daily price must be bigger than 0");
        }
    }
}
