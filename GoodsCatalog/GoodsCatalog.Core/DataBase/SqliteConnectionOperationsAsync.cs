using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Platform.Core;
using SQLite;

namespace GoodsCatalog.Core.DataBase
{
    public class SqliteConnectionOperationsAsync : IOperationsAsync
    {
        private SQLiteAsyncConnection connection;

        public SqliteConnectionOperationsAsync(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        public void Dispose()
        {
            connection.DisposeIfDisposable();
            connection = null;
        }

        public async Task<int> DropTableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await DropTableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<int> DropTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
          
            return await connection.DropTableAsync<TEntity>();
        }

        public async Task<int> CreateTableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await CreateTableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<int> CreateTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            var tableResult = await connection.CreateTableAsync<TEntity>(CreateFlags.ImplicitPK |CreateFlags.AutoIncPK);

            try
            {
                var typeResult = 1;

                return typeResult;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<IEnumerable<TEntity>> TableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await TableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<IEnumerable<TEntity>> TableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.Table<TEntity>().ToListAsync();
        }

        public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new()
        {
            return await InsertAllAsync(objects, CancellationToken.None);
        }

        public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.InsertAllAsync(objects);
        }
    }
}