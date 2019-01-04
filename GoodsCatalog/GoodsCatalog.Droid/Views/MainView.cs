using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Binding.Droid.BindingContext;
using GoodsCatalog.Core.ViewModels;
using GoodsCatalog.Droid.Adapters;
using Android.Support.V7.Widget;

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
            var linearLayoutManager = new LinearLayoutManager(this);
            var dividerItemDecoration = new DividerItemDecoration(cataloglist.Context, linearLayoutManager.Orientation);

            cataloglist.SetLayoutManager(linearLayoutManager);
            cataloglist.AddItemDecoration(dividerItemDecoration);

            cataloglist.Adapter = adapter;
        }
    }
}