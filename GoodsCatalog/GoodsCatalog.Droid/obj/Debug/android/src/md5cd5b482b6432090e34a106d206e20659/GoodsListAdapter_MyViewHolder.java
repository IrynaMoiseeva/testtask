package md5cd5b482b6432090e34a106d206e20659;


public class GoodsListAdapter_MyViewHolder
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GoodsCatalog.Droid.Adapters.GoodsListAdapter+MyViewHolder, GoodsCatalog.Droid", GoodsListAdapter_MyViewHolder.class, __md_methods);
	}


	public GoodsListAdapter_MyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == GoodsListAdapter_MyViewHolder.class)
			mono.android.TypeManager.Activate ("GoodsCatalog.Droid.Adapters.GoodsListAdapter+MyViewHolder, GoodsCatalog.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
