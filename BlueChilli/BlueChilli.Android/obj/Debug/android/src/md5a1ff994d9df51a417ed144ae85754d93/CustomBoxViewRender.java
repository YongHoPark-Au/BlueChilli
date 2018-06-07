package md5a1ff994d9df51a417ed144ae85754d93;


public class CustomBoxViewRender
	extends md51558244f76c53b6aeda52c8a337f2c37.BoxRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSizeChanged:(IIII)V:GetOnSizeChanged_IIIIHandler\n" +
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("BlueChilli.Droid.Renderer.CustomBoxViewRender, BlueChilli.Android", CustomBoxViewRender.class, __md_methods);
	}


	public CustomBoxViewRender (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomBoxViewRender.class)
			mono.android.TypeManager.Activate ("BlueChilli.Droid.Renderer.CustomBoxViewRender, BlueChilli.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomBoxViewRender (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomBoxViewRender.class)
			mono.android.TypeManager.Activate ("BlueChilli.Droid.Renderer.CustomBoxViewRender, BlueChilli.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomBoxViewRender (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomBoxViewRender.class)
			mono.android.TypeManager.Activate ("BlueChilli.Droid.Renderer.CustomBoxViewRender, BlueChilli.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onSizeChanged (int p0, int p1, int p2, int p3)
	{
		n_onSizeChanged (p0, p1, p2, p3);
	}

	private native void n_onSizeChanged (int p0, int p1, int p2, int p3);


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);

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
