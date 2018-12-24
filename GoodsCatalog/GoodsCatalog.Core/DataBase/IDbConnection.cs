namespace GoodsCatalog.Core.DataBase
{
    public interface IDbConnectionManager
    {
        IOperationsAsync GetConnection();
    } 
}
