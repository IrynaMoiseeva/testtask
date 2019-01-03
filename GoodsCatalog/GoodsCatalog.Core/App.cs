using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

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

        }
    }
}
