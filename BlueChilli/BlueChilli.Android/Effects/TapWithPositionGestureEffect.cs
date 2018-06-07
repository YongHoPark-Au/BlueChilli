using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using BlueChilli.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TapWithPositionGestureEffect = BlueChilli.Droid.Effects.TapWithPositionGestureEffect;


[assembly: ResolutionGroupName("BlueChilli")]
[assembly: ExportEffect(typeof(TapWithPositionGestureEffect), "TapWithPositionGestureEffect")]

namespace BlueChilli.Droid.Effects
{
    public class TapWithPositionGestureEffect : PlatformEffect
    {
        private GestureDetectorCompat gestureRecognizer;
        private readonly InternalGestureDetector tapDetector;
        private Command<Point> tapWithPositionCommand;
        private DisplayMetrics displayMetrics;

        public TapWithPositionGestureEffect()
        {
            tapDetector = new InternalGestureDetector
            {
                TapAction = motionEvent =>
                {
                    var tap = tapWithPositionCommand;
                    if (tap != null)
                    {
                        var x = motionEvent.GetX();
                        var y = motionEvent.GetY();

                        var point = PxToDp(new Point(x, y));
                        Log.WriteLine(LogPriority.Debug, "gesture", $"Tap detected at {x} x {y} in forms: {point.X} x {point.Y}");
                        if (tap.CanExecute(point))
                            tap.Execute(point);
                    }
                }
            };
        }

        private Point PxToDp(Point point)
        {
            point.X = point.X / displayMetrics.Density;
            point.Y = point.Y / displayMetrics.Density;
            return point;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            tapWithPositionCommand = Gesture.GetCommand(Element);
        }

        protected override void OnAttached()
        {
            var control = Control ?? Container;

            var context = control.Context;
            displayMetrics = context.Resources.DisplayMetrics;
            tapDetector.Density = displayMetrics.Density;

            if (gestureRecognizer == null)
                gestureRecognizer = new GestureDetectorCompat(context, tapDetector);
            control.Touch += Control_Touch;

            OnElementPropertyChanged(new PropertyChangedEventArgs(String.Empty));
        }

        private void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            gestureRecognizer?.OnTouchEvent(e.Event);
        }


        protected override void OnDetached()
        {
            var control = Control ?? Container;
            control.Touch -= Control_Touch;
        }


        sealed class InternalGestureDetector : GestureDetector.SimpleOnGestureListener
        {
            public Action<MotionEvent> TapAction { get; set; }
            public float Density { get; set; }

            public override bool OnSingleTapUp(MotionEvent e)
            {
                TapAction?.Invoke(e);
                return true;
            }
        }
    }
}