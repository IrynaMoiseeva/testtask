﻿using System;
using System.Collections.Specialized;
using System.Net;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Droid.Support.V7.RecyclerView;
using GoodsCatalog.Core.Model;

namespace GoodsCatalog.Droid.Adapters
{
    public class GoodsListAdapter : MvxRecyclerAdapter
    {
        public View View;

        public GoodsListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {
          
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);

            View = this.InflateViewForHolder(parent, viewType, itemBindingContext);

            return new MyViewHolder(View, itemBindingContext);
        }

        public static Bitmap GetBitmapFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(new Uri(url));
                    if (bytes != null && bytes.Length > 0)
                    {
                        return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message = {ex.Message} StackTrace = {ex.StackTrace}");
            }

            return null;
        }

        public class MyViewHolder : MvxRecyclerViewHolder
        {
            public TextView name;
            public TextView price;
            public ImageView photo;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)

            {
                name = itemView.FindViewById<TextView>(Resource.Id.name);
                price = itemView.FindViewById<TextView>(Resource.Id.price);
                photo = itemView.FindViewById<ImageView>(Resource.Id.photo);
            }
        }

        protected object GetElementAt(int position)
        {
            return ItemsSource.ElementAt(position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var catalog = ItemsSource.ElementAt(position) as Catalog;

            MyViewHolder myHolder = holder as MyViewHolder;

            Bitmap bbb = GetBitmapFromUrl(catalog.PhotoUrl);
            myHolder.photo.SetImageBitmap(bbb);


            myHolder.name.Text = catalog.Name;
            myHolder.price.Text = catalog.Price.ToString();

        }

        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
