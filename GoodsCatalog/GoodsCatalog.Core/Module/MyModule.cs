using Autofac;
using GoodsCatalog.Core.Services;
using GoodsCatalog.Core.Services.Abstract;

namespace GoodsCatalog.Core.Module
{
    public class MyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<PlatformService>().As<IPlatformService>();
        }
    }
}
