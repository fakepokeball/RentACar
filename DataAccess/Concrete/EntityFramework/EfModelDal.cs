﻿using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfModelDal : IModelDal
{
    public Model Add(Model entity)
    {
        throw new NotImplementedException();
    }

    public Model Delete(Model entity)
    {
        throw new NotImplementedException();
    }

    public Model? Get(Func<Model, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetList(Func<Model, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Model Update(Model entity)
    {
        throw new NotImplementedException();
    }
}
