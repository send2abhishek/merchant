using Attra.EWallet.DAL.Models;
using Attra.EWallet.Interface;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OtpVerfiyPopUp 
	{

        private string EmailId;
        private string MobileNbr;

        public static BindableProperty PinProperty = BindableProperty.
        Create("Pin", typeof(string), typeof(OtpVerfiyPopUp), defaultBindingMode: BindingMode.OneWayToSource);

        public  string Pin
        {
            get
            {
                return (string)GetValue(PinProperty);
            }
            set
            {
                SetValue(PinProperty, value);
            }
        }
        public OtpVerfiyPopUp (string email,string phnbr)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            EmailId = email;
            MobileNbr = phnbr;
            Pin = string.Empty;
            Pin1.TextChanged += Pin1_TextChanged;
            Pin2.TextChanged += Pin2_TextChanged;
            Pin3.TextChanged += Pin3_TextChanged;
            Pin4.TextChanged += Pin4_TextChanged;
        }

        private void Pin4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin4.Text.Length > 0)
                Pin4.Unfocus();
            else
                Pin3.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        }

        private void Pin3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin3.Text.Length > 0)
                Pin4.Focus();
            else
                Pin2.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        }

        private void Pin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin2.Text.Length > 0)
                Pin3.Focus();
            else
                Pin1.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        }

        private void Pin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin1.Text.Length > 0)
                Pin2.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {


            //PopupNavigation.Instance.PopAsync(true);

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            DependencyService.Get<RegistertionNotify>().onStartRegistration("Attempting To Verify OTP ");

            DAL.Services.ApiServices services = new DAL.Services.ApiServices();
            try
            {
                OtpResponse otpResponse = await services.ValidateOtp(double.Parse(Pin.Trim()), EmailId, MobileNbr);
                DependencyService.Get<RegistertionNotify>().onRegistrationFail(otpResponse.message);
                DependencyService.Get<RegistertionNotify>().onCompleteRegistration();

                if ((otpResponse.message.Trim()).Equals("OTP Verified")){


                    DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
                    await Navigation.PopAsync();
                    await PopupNavigation.Instance.PopAsync(true);
                    await Navigation.PopToRootAsync();
                    //await Navigation.PushModalAsync(new LoginPage());


                }

            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                DependencyService.Get<RegistertionNotify>().onRegistrationFail("Server Problem !");
                DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
            }

            

        }

        private async void TapGestureRecognizer_ReSendOTP(object sender, EventArgs e)
        {

            bool OTPResend = false;
            DependencyService.Get<RegistertionNotify>().onStartRegistration("Attempting To Rsend OTP ");

            DAL.Services.ApiServices services = new DAL.Services.ApiServices();
            try
            {
                OTPResend = await services.ReSendOtpOtp(EmailId, MobileNbr);
                

                if (OTPResend)
                {


                    DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
                    DependencyService.Get<RegistertionNotify>().onRegistrationFail("OTP Resent,Plese check Your Mail!");


                }

                else
                {
                    DependencyService.Get<RegistertionNotify>().onRegistrationFail("Something went wrong,In order to send OTP!");
                    DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
                }

            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                DependencyService.Get<RegistertionNotify>().onRegistrationFail("Server Problem !");
                DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
            }

        }

        //private async void OnTapValidate(object sender, EventArgs args)
        //{
        //    await Navigation.PushAsync(new CreatePswdPage());  
        //}


    }
    }
