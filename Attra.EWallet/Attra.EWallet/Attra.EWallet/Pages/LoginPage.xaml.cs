using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Attra.EWallet.DAL.Services;
using Attra.EWallet.Pages.Menu;

namespace Attra.EWallet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);


            Email.Completed += (object sender, EventArgs e) =>

            {
                Password.Focus();
            };
        }

        private async void OnTapRegister(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.RegisterPage());
        }

        private async void OnLoginClick(object sender, EventArgs e)
        {
            LoginApi Login = new LoginApi();
            try
            {
                bool res = await Login.LoginUserDetails(Email.Text, Password.Text);
                if (res)
                {
                    await Navigation.PushModalAsync(new MasterDetail());
                }
                //if (Email.Text == "send2abhishek@live.com" && Password.Text == "Default_pass")

                //{
                //    await Navigation.PushModalAsync(new LandingPage());
                //}
                else
                {
                    await DisplayAlert("Error", "Invalid Login, try again", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message + ex.StackTrace, "OK");

            }
        }

       // public ListStringTypeConverter Email { get; }

        //public void  { get; set; }

        private async void OnTapForgotPswd(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ForgotPswdPage());
        }
    }
}