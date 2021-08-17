using System.Collections.Generic;

namespace MediatR_WebApplication
{
    public interface IRetrieve<in TKey, out TEntity>
    {
        TEntity Retrieve(TKey key);

        IEnumerable<TEntity> RetrieveMany();
    }

    public interface ICreate<in TEntity>
    {
        void Create(TEntity entity);
    }

    public interface IUpdate<in TEntity>
    {
        void Update(TEntity entity);
    }

    public interface IDelete<in TKey>
    {
        void Delete(TKey key);
    }

}
