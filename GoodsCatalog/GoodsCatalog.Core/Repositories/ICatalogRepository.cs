using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsCatalog.Core.DataBase;
using GoodsCatalog.Core.Model;

namespace GoodsCatalog.Core.Repositories
{
   public interface ICatalogRepository: ILocalRepositoryOperations<Catalog>
    {
        Task<IEnumerable<Catalog>> GetCatalog();
    }
}
