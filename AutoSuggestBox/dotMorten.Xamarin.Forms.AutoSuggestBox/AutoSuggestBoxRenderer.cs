﻿#if !NETSTANDARD2_0
#if __ANDROID__
using Xamarin.Forms.Platform.Android;
using NativeAutoSuggestBox = Android.Widget.AutoCompleteTextView;
#elif __IOS__
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using NativeAutoSuggestBox = UIKit.UIView;
#elif NETFX_CORE
using Xamarin.Forms.Platform.UWP;
using NativeAutoSuggestBox = Windows.UI.Xaml.Controls.AutoSuggestBox;
#endif

namespace dotMorten.Xamarin.Forms
{
    internal class AutoSuggestBoxRenderer : ViewRenderer<AutoSuggestBox, NativeAutoSuggestBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<dotMorten.Xamarin.Forms.AutoSuggestBox> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(e.NewElement?.NativeAutoSuggestBox);
            }
        }

#if __IOS__
        static readonly int baseHeight = 10;

        public AutoSuggestBoxRenderer()
        {
            Frame = new RectangleF(0, 20, 320, 40);
        }

        public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            var baseResult = base.GetDesiredSize(widthConstraint, heightConstraint);
            var testString = new Foundation.NSString("Tj");
            var testSize = testString.GetSizeUsingAttributes(new UIStringAttributes { Font = Element.inputText.Font });
            double height = baseHeight + testSize.Height;
            height = Math.Round(height);

            return new SizeRequest(new global::Xamarin.Forms.Size(baseResult.Request.Width, height));
        }
#endif
    }
}
#endif