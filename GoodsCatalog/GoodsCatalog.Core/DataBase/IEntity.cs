using SQLite.Net.Attributes;

namespace GoodsCatalog.Core.DataBase
{
    public interface IEntity
    {
        [PrimaryKey, AutoIncrement]
         int? Id { get; set; }
    }
}
