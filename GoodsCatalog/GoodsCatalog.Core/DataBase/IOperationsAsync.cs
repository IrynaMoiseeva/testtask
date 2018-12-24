using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodsCatalog.Core.DataBase
{
    public interface IOperationsAsync : IDisposable
    {
         
        Task<int> DropTableAsync<TEntity>()
            where TEntity : class, IEntity, new();
       
        Task<int> CreateTableAsync<TEntity>()
            where TEntity : class, IEntity, new();

        Task<int> CreateTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new();

        Task<IEnumerable<TEntity>> TableAsync<TEntity>()
            where TEntity : class, IEntity, new();

        Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new();
      
        Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new();
    }
}
