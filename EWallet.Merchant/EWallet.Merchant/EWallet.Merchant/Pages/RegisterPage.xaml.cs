using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWallet.Merchant.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string passwordcomplexity = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public RegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BackgroundImage = "bg_img.jpg";
        }



        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (entPhNbr.IsFocused)
            {

                if ((!(entPhNbr.Text.Length >= 10)) && (entPhNbr.IsFocused))
                {

                    entPhNbrError.IsVisible = true;
                    entPhNbrError.Text = "Invalid Mobile Number !";
                    return;


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

                if (entlength > 15)
                {
                    entNameError.IsVisible = true;
                    entNameError.Text = "Invalid Name !";

                }

                else
                {
                    entNameError.IsVisible = false;
                    entNameError.Text = "";
                }

            }

            if (entPassword.IsFocused)
            {

                Regex regular = new Regex(passwordcomplexity);
                var password = entPassword.Text;
                if (!(regular.IsMatch(password)))
                {
                    entPasswordError.IsVisible = true;
                    entPasswordError.Text = "Invalid Password !";
                }
                else
                {
                    entPasswordError.IsVisible = false;
                    entPasswordError.Text = "";
                }
            }

            if (entCnfPassword.IsFocused)
            {
                Regex regular = new Regex(passwordcomplexity);
                var Confirmpassword = entCnfPassword.Text;

                if (!(regular.IsMatch(Confirmpassword)))
                {
                    entCnfPasswordError.IsVisible = true;
                    entCnfPasswordError.Text = "Invalid Password !";
                }
                else
                {
                    entCnfPasswordError.IsVisible = false;
                    entCnfPasswordError.Text = "";
                }
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
            else if (String.IsNullOrEmpty(entLocation.Items[entLocation.SelectedIndex]))
            {
                entLocationError.IsVisible = true;
                entLocationError.Text = "Please select the proper location !";
                return false;
            }

            else if (String.IsNullOrEmpty(entMerchant.Items[entMerchant.SelectedIndex]))
            {
                entMerchantError.IsVisible = true;
                entMerchantError.Text = "Please select the proper merchant !";
                return false;
            }


            else if (String.IsNullOrEmpty(entPassword.Text))
            {
                entPasswordError.IsVisible = true;
                entPasswordError.Text = "Password can't be empty !";
                return false;
            }

            else if (String.IsNullOrEmpty(entCnfPassword.Text))
            {
                entCnfPasswordError.IsVisible = true;
                entCnfPassword.Text = "Confirm Password can't be empty !";
                return false;
            }






            else
            {

                entPhNbrError.IsVisible = false;
                entNameError.IsVisible = false;
                entLocationError.IsVisible = false;
                entMerchantError.IsVisible = false;
                entPasswordError.IsVisible = false;
                entCnfPasswordError.IsVisible = false;
                entCnfPassword.Text = "";
                entPasswordError.Text = "";
                entNameError.Text = "";
                entPhNbrError.Text = "";
                entLocationError.Text = "";
                entMerchantError.Text = "";


            }

            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (callValidation())
            {
                DAL.Services.ApiServices services = new DAL.Services.ApiServices();

                //bool RegistrationStatus = await services.RegisterUser(entName.Text, entPhNbr.Text.ToString(),
                //  Int32.Parse(entEmpId.Text), entEmail.Text);


                await Navigation.PushAsync(new OtpVerify());


                
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Terms And Conditions", "Terms And Conditions goes here", "Okay");
        }
    }
}