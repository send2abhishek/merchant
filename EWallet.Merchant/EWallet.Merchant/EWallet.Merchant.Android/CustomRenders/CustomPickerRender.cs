using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EWallet.Merchant.CustomControls;
using EWallet.Merchant.Droid.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRender))]

namespace EWallet.Merchant.Droid.CustomRenders
{
    public class CustomPickerRender : Xamarin.Forms.Platform.Android.PickerRenderer
    {
        public CustomPickerRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            SetControlStyle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetControlStyle();
        }

        private void SetControlStyle()
        {
            if (Control != null)
            {
                Drawable imgDropDownArrow = Resources.GetDrawable(Resource.Drawable.ddarrow);
                imgDropDownArrow.SetBounds(5, 5, 5, 5);
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, imgDropDownArrow, null);
               
            }
        }
    }
}