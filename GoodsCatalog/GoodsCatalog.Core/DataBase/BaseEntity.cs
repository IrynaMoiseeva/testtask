using SQLite.Net.Attributes;

namespace GoodsCatalog.Core.DataBase
{
    public abstract class BaseEntity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
    }
}
