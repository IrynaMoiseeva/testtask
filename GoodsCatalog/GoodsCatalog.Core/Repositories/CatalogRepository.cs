using System.Threading.Tasks;
using System.Collections.Generic;
using GoodsCatalog.Core.DataBase;
using GoodsCatalog.Core.Model;

namespace GoodsCatalog.Core.Repositories
{
    public class CatalogRepository : LocalRepositoryAsyncBase<Catalog>, ICatalogRepository
    {
        public CatalogRepository(IDbConnectionManager connectionFactory)
            : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<Catalog>> GetCatalog()
        {
            return await ReadAll();
        }
    }
}