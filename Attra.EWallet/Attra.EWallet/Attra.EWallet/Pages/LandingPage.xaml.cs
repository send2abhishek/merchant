using Attra.EWallet.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LandingPage : ContentPage
	{
		public LandingPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());

        }

        private async void LoginTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}