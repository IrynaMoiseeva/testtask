package mono.com.google.android.youtube.player;


public class YouTubePlayer_PlaylistEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubePlayer.PlaylistEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNext:()V:GetOnNextHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaylistEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onPlaylistEnded:()V:GetOnPlaylistEndedHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaylistEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onPrevious:()V:GetOnPreviousHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaylistEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Youtube.Player.IYouTubePlayerPlaylistEventListenerImplementor, Naxam.YoutubePlayerApi.Droid", YouTubePlayer_PlaylistEventListenerImplementor.class, __md_methods);
	}


	public YouTubePlayer_PlaylistEventListenerImplementor ()
	{
		super ();
		if (getClass () == YouTubePlayer_PlaylistEventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Youtube.Player.IYouTubePlayerPlaylistEventListenerImplementor, Naxam.YoutubePlayerApi.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onNext ()
	{
		n_onNext ();
	}

	private native void n_onNext ();


	public void onPlaylistEnded ()
	{
		n_onPlaylistEnded ();
	}

	private native void n_onPlaylistEnded ();


	public void onPrevious ()
	{
		n_onPrevious ();
	}

	private native void n_onPrevious ();

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
