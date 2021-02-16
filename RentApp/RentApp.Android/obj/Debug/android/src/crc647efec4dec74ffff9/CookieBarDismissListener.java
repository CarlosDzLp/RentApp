package crc647efec4dec74ffff9;


public class CookieBarDismissListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.aviran.cookiebar2.CookieBarDismissListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDismiss:(I)V:GetOnDismiss_IHandler:Org.Aviran.CookieBar2.ICookieBarDismissListenerInvoker, AviranAbady.CookieBar2\n" +
			"";
		mono.android.Runtime.register ("Org.Aviran.CookieBar2.CookieBarDismissListener, AviranAbady.CookieBar2", CookieBarDismissListener.class, __md_methods);
	}


	public CookieBarDismissListener ()
	{
		super ();
		if (getClass () == CookieBarDismissListener.class)
			mono.android.TypeManager.Activate ("Org.Aviran.CookieBar2.CookieBarDismissListener, AviranAbady.CookieBar2", "", this, new java.lang.Object[] {  });
	}


	public void onDismiss (int p0)
	{
		n_onDismiss (p0);
	}

	private native void n_onDismiss (int p0);

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
