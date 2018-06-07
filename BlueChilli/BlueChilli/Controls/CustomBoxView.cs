using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlueChilli.Controls
{
    public class CustomBoxView : BoxView
    {
        //Create a Bindable Property For CornerRadius  
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(CustomBoxView), 0.0);
        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
