package crc647efec4dec74ffff9;


public class ActionClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.aviran.cookiebar2.OnActionClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:()V:GetOnClickHandler:Org.Aviran.CookieBar2.IOnActionClickListenerInvoker, AviranAbady.CookieBar2\n" +
			"";
		mono.android.Runtime.register ("Org.Aviran.CookieBar2.ActionClickListener, AviranAbady.CookieBar2", ActionClickListener.class, __md_methods);
	}


	public ActionClickListener ()
	{
		super ();
		if (getClass () == ActionClickListener.class)
			mono.android.TypeManager.Activate ("Org.Aviran.CookieBar2.ActionClickListener, AviranAbady.CookieBar2", "", this, new java.lang.Object[] {  });
	}


	public void onClick ()
	{
		n_onClick ();
	}

	private native void n_onClick ();

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
