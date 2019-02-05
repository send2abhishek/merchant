using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWallet.Merchant.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OtpVerify : ContentPage
	{
		public OtpVerify ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BackgroundImage = "bg_img.jpg";
            PopupNavigation.Instance.PushAsync(new OtpVerfiyPopUp());
        }

        protected override bool OnBackButtonPressed()
        {
            PopupNavigation.Instance.PopAsync(true);

            return base.OnBackButtonPressed();
        }
    }
}