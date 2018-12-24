using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using GoodsCatalog.Core.DataBase;
using GoodsCatalog.Core.Model;
using GoodsCatalog.Core.Repositories;
using SQLite;

namespace GoodsCatalog.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            CreatableTypes()
                 .EndingWith("Repository")
                 .AsInterfaces()
                 .RegisterAsLazySingleton();

            Mvx.RegisterType<IDbConnectionManager, DbConnectionManager>();

            Mvx.LazyConstructAndRegisterSingleton<ICatalogRepository, CatalogRepository>();
        }
    }
}
