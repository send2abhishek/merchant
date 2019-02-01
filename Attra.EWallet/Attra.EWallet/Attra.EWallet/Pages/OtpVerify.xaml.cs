using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OtpVerify : ContentPage
	{
		public OtpVerify ()
		{
			InitializeComponent ();
            PopupNavigation.Instance.PushAsync(new OtpVerfiyPopUp());

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //PopupNavigation.Instance.PushAsync(new OtpVerfiyPopUp());
        }


        protected override bool OnBackButtonPressed()
        {
            PopupNavigation.Instance.PopAsync(true);

            return base.OnBackButtonPressed();
        }


    }
}