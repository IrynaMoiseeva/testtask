using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodsCatalog.Core.DataBase
{
    public interface  ILocalRepositoryOperations<TEntity> : IDisposable
        where TEntity : class, IEntity, new()
    {
        Task<int> InsertAll(IEnumerable<TEntity> objects);

        Task<IEnumerable<TEntity>> ReadAll();
       
        Task DropTable();

        Task CreateTable();
    }
}