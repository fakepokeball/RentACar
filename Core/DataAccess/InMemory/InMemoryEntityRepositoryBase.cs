using Core.Entities;
using System.Collections.Immutable;

namespace Core.DataAccess.InMemory;

public abstract class InMemoryEntityRepositoryBase<TEntity, TEntityId>
    : IEntityRepository<TEntity, TEntityId>
    where TEntity : class, IEntity<TEntityId>, new()
{
    protected readonly HashSet<TEntity> Entities = new();

    protected abstract TEntityId generateId();

    public TEntity Add(TEntity entity)
    {
        entity.Id = generateId();
        entity.CreatedAt = DateTime.UtcNow;
        Entities.Add(entity);
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        return entity;
    }

    public TEntity? Get(Func<TEntity, bool> predicate)
    {
        TEntity? entity = Entities.FirstOrDefault(predicate);
        return entity;
    }

    public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null )
    {
        IQueryable<TEntity> query = Entities.AsQueryable();
        if (predicate != null)
        {
            query = query.Where(predicate).AsQueryable();
        }
        return query.ToArray();
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        return entity;
    }
}
