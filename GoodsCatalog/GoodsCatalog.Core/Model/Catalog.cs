using GoodsCatalog.Core.DataBase;
using SQLite.Net.Attributes;

namespace GoodsCatalog.Core.Model
{
    [Table("Catalog")]
    public class Catalog : IEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}