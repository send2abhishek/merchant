//using Attra.EWallet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Attra.EWallet.DAL.Services;

namespace Attra.EWallet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        //public static BindableProperty PinProperty = BindableProperty.
        //Create("Pin", typeof(string), typeof(RegisterPage), defaultBindingMode: BindingMode.OneWayToSource);

        //public string Pin
        //{
        //    get
        //    {
        //        return (string)GetValue(PinProperty);
        //    }
        //    set
        //    {
        //        SetValue(PinProperty, value);
        //    }
        //}

        private async void OnTapSignin(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.LoginPage());
        }

        public RegisterPage()
        {
            InitializeComponent();
            //this.BackgroundImage = "background_screen_two.png";

            NavigationPage.SetHasNavigationBar(this, false);

            //Pin = string.Empty;
            //Pin1.TextChanged += Pin1_TextChanged;
            //Pin2.TextChanged += Pin2_TextChanged;
            //Pin3.TextChanged += Pin3_TextChanged;
            //Pin4.TextChanged += Pin4_TextChanged;
        }

        //private void Pin4_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (Pin4.Text.Length > 0)
        //        Pin4.Unfocus();
        //    else
        //        Pin3.Focus();
        //    Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        //}

        //private void Pin3_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (Pin3.Text.Length > 0)
        //        Pin4.Focus();
        //    else
        //        Pin2.Focus();
        //    Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        //}

        //private void Pin2_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (Pin2.Text.Length > 0)
        //        Pin3.Focus();
        //    else
        //        Pin1.Focus();
        //    Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        //}

        //private void Pin1_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (Pin1.Text.Length > 0)
        //        Pin2.Focus();
        //    Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text;
        //}

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (entPhNbr.IsFocused)
            {

                if ((!(entPhNbr.Text.Length >= 10)) && (entPhNbr.IsFocused))
                {

                    entPhNbrError.IsVisible = true;
                    entPhNbrError.Text = "Invalid Mobile Number !";
                    return ;


                }

                else
                {
                    entPhNbrError.IsVisible = false;
                    entPhNbrError.Text = "";
                }

            }

            if (entName.IsFocused)
            {

                //int entlength = Int32.Parse(entName.Text);
                int entlength = entName.Text.Length;

                //if (entlength > 15)
                //{
                //    entNameError.IsVisible = true;
                //    entNameError.Text = "Invalid Name !";

                //}

                //else
                //{
                //    entNameError.IsVisible = false;
                //    entNameError.Text = "";
                //}

            }


            if (entEmail.IsFocused)
            {

                var emailText = entEmail.Text;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex regular = new Regex(strRegex);



                if (!(regular.IsMatch(emailText)))
                {
                    entEmailError.Text = "Invalid Email";
                    entEmailError.IsVisible = true;
                    return;
                }

                else
                {
                    entEmailError.Text = "";
                    entEmailError.IsVisible = false;
                }

                //if (entEmpId.IsFocused)
                //{
                    
                //}
            }


        }


        private bool callValidation()
        {

            if (String.IsNullOrEmpty(entPhNbr.Text))
            {
                entPhNbrError.IsVisible = true;
                entPhNbrError.Text = "Mobile number can't be empty !";
                return false;
            }

            else if (String.IsNullOrEmpty(entName.Text))
            {
                entNameError.IsVisible = true;
                entNameError.Text = "Name can't be empty !";
                return false;
            }

            else if (String.IsNullOrEmpty(entEmail.Text))
            {
                entEmailError.IsVisible = true;
                entEmailError.Text = "Email can't be empty !";
                return false;

            }

            else if (String.IsNullOrEmpty(entEmpId.Text))
            {
                entEmpIdError.IsVisible = true;
                entEmpIdError.Text = "EmpId can't be empty !";
                return false;
            }

            else
            {
                entEmpIdError.IsVisible = false;
                entPhNbrError.IsVisible = false;
                entEmailError.IsVisible = false;
                entNameError.IsVisible = false;
                entNameError.Text = "";
                entEmailError.Text = "";
                entPhNbrError.Text = "";
                entEmpIdError.Text = "";
            }

            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (callValidation())
            {

                

               // ApiServices services = new ApiServices();

                 DAL.Services.ApiServices services = new DAL.Services.ApiServices();
                bool RegistrationStatus = await services.RegisterUser(entName.Text, entPhNbr.Text.ToString(),
                  Int32.Parse(entEmpId.Text), entEmail.Text);


                //bool RegistrationStatus = true;

                if (RegistrationStatus)
                {

                    await DisplayAlert("Hi", "User Registered...", "Okay");
                    await Navigation.PushAsync(new OtpVerify());
                }
                else
                {
                    await DisplayAlert("Alert", "Something went wrong...", "Cancel");
                }
            }
        }
    }
}