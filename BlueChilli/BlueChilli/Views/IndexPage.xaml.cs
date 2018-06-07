using BlueChilli.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueChilli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexPage : ContentPage
	{
		public IndexPage ()
		{
			InitializeComponent ();
            BindingContext = new IndexViewModel(absoluteLayout);
            makeCleanButton();
        }

        private void btnCleanClicked(object sender, EventArgs args)
        {
            absoluteLayout.Children.Clear();
            makeCleanButton();
        }

        private void makeCleanButton()
        {
            Button button = new Button { Text = "CLEAN", BackgroundColor = Color.Azure };
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(1, 1, 100, 40));
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);

            button.Clicked += btnCleanClicked;
            absoluteLayout.Children.Add(button);
        }

        
    }
}