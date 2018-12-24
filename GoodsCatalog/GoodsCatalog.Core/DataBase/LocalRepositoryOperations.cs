using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GoodsCatalog.Core.DataBase
{

    public abstract class LocalRepositoryAsyncBase<TEntity> : DataBaseConnection,ILocalRepositoryOperations<TEntity>
        where TEntity : class,IEntity,new()
    {
        private const int ErrorValue = -1;

        private TEntity ErrorEntity() => default(TEntity);

        private IEnumerable<TEntity> ErrorEntityEnum => new TEntity[0];

        protected LocalRepositoryAsyncBase(IDbConnectionManager dbmanager)
                    : base(dbmanager)
        {
        }

        public async Task<IEnumerable<TEntity>> ReadAll()
        {
            try
            {

                return await DbConnection.TableAsync<TEntity>();
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorEntityEnum;
            }
        }

        public async Task DropTable()
        {
            try
            {
                await DbConnection.DropTableAsync<TEntity>().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);

            }
        }
      
        public async Task<int> InsertAll(IEnumerable<TEntity> items)
        {
            try
            {
                return await DbConnection.InsertAllAsync(items).ConfigureAwait(false);
            }

            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }

        public async Task CreateTable()
        {
            try
            {
                await DbConnection.CreateTableAsync<TEntity>().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);

            }
        }

        private void LogException(Exception e)
        {
            Debug.WriteLine("Exception");
                
        }
    }
}
