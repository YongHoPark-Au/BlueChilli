using BlueChilli.Controls;
using BlueChilli.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRender))]
namespace BlueChilli.iOS.Renderer
{
    public class CustomBoxViewRender : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null) return;
            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((CustomBoxView)this.Element).CornerRadius / 2.0f;
        }
    }
}