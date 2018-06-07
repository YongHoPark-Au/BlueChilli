package md5bfed3f7bd34dd0ac3a676ee3b502b2fa;


public class TapWithPositionGestureEffect_InternalGestureDetector
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSingleTapUp:(Landroid/view/MotionEvent;)Z:GetOnSingleTapUp_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("BlueChilli.Droid.Effects.TapWithPositionGestureEffect+InternalGestureDetector, BlueChilli.Android", TapWithPositionGestureEffect_InternalGestureDetector.class, __md_methods);
	}


	public TapWithPositionGestureEffect_InternalGestureDetector ()
	{
		super ();
		if (getClass () == TapWithPositionGestureEffect_InternalGestureDetector.class)
			mono.android.TypeManager.Activate ("BlueChilli.Droid.Effects.TapWithPositionGestureEffect+InternalGestureDetector, BlueChilli.Android", "", this, new java.lang.Object[] {  });
	}


	public boolean onSingleTapUp (android.view.MotionEvent p0)
	{
		return n_onSingleTapUp (p0);
	}

	private native boolean n_onSingleTapUp (android.view.MotionEvent p0);

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
