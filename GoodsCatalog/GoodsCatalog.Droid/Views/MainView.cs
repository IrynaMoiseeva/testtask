using System;
using System.Net.Http;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.BindingContext;
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