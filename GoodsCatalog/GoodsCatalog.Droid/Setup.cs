using System;
using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Autofac.Extras.MvvmCross;
using GoodsCatalog.Droid.Properties;
using GoodsCatalog.Core.Services;
using GoodsCatalog.Core;
using GoodsCatalog.Core.Data;

namespace GoodsCatalog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var container = Mvx.Resolve<IPlatformService>();
            return new App();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => 
            new List<Assembly>(base.AndroidViewAssemblies) 
                {typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly};

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter =
                new MvxAndroidViewPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            return mvxFragmentsPresenter;
        }

        protected override IMvxIoCProvider CreateIocProvider()
        {
            Dictionary<Type, Type> mappedtypes = new Dictionary<Type, Type>();
            mappedtypes.Add(typeof(PlatformService_Android), typeof(IPlatformService));

            Bootstarpper bootstarpper = new Bootstarpper();
            var container = bootstarpper.Build(mappedtypes);

            return new AutofacMvxIocProvider(container);
        }
    }
}