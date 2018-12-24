using System;
using GoodsCatalog.Core.Services;
using SQLite;

namespace GoodsCatalog.Core.DataBase
{

    public class DbConnectionManager: IDbConnectionManager
    {
        private readonly IPlatformService sqlitePlatformContext;
        private static object syncObj = new Object();
        public static SQLiteAsyncConnection connection;

        public string dbPath;
        private volatile IOperationsAsync asyncConnection;

        public DbConnectionManager(IPlatformService sqlitePlatformContext)
        {
            this.sqlitePlatformContext = sqlitePlatformContext;
            dbPath = sqlitePlatformContext.DestinationPath;
        }

        public void DropConnection()
        {
            if (asyncConnection == null)
                return;

            lock (syncObj)
            {
                asyncConnection = null;
            }
        }

        public IOperationsAsync GetConnection()
        {
            if (asyncConnection != null)
                return asyncConnection;

            lock (syncObj)
            {
                if (asyncConnection != null)
                    return asyncConnection;

                var sqLiteAsyncConnection = CreateSqLiteAsyncConnection();
                asyncConnection = new SqliteConnectionOperationsAsync(sqLiteAsyncConnection);
            }

            return asyncConnection;
        }

        private SQLiteAsyncConnection CreateSqLiteAsyncConnection()
        {
            var sqLiteAsyncConnection = new SQLiteAsyncConnection(dbPath);
           
            return sqLiteAsyncConnection;
        }
    }
}
