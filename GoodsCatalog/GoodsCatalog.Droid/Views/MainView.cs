using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Binding.Droid.BindingContext;
using GoodsCatalog.Core.ViewModels;
using GoodsCatalog.Droid.Adapters;

namespace GoodsCatalog.Droid.Views
{
    [Activity(Label = "Goods Catalog", MainLauncher = true, Theme = "@style/MyTheme.Base")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainView);

            var adapter = new GoodsListAdapter((IMvxAndroidBindingContext)this.BindingContext);

            MvxRecyclerView cataloglist = FindViewById<MvxRecyclerView>(Resource.Id.catalog);
           
            cataloglist.Adapter = adapter;
        }
    }
}