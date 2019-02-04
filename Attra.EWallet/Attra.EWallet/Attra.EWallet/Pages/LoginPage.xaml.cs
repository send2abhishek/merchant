using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Attra.EWallet.DAL.Services;
using Attra.EWallet.Pages.Menu;
using System.Text.RegularExpressions;

namespace Attra.EWallet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
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
            if (ValidationCompleted())
            {
                LoginApi Login = new LoginApi();
                //try
                //{
                bool res = await Login.LoginUserDetails(Email.Text, Password.Text);
                if (res)
                {
                    await DisplayAlert("Welcome", "Login successful...", "Okay");
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
                //}
                //catch(Exception ex)
                //{
                //    await DisplayAlert("Error", ex.Message + ex.StackTrace, "OK");

                //}
            }
        }

        // public ListStringTypeConverter Email { get; }

        //public void  { get; set; }

        private void OnTapForgotPswd(Object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new ForgotPswdPage());  
            ForgotPswd_overlay.IsVisible = true;
        }
        private async void OnSendOTPBtnClick(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new OtpVerfiyPopUp());
        }

        private void MobTextChanged(Object sender, EventArgs args)
        {
            if (Email.IsFocused)
            {
                if ((Email.Text.Length < 10) && (Email.IsFocused))
                {
                    ErrorMsg.IsVisible = true;
                    ErrorMsg.Text = "Invalid Mobile Number !";
                    return;
                }

                else
                {
                    ErrorMsg.IsVisible = false;
                    ErrorMsg.Text = "";
                }
            }
        }

        private void PswdTextChanged(Object sender, EventArgs args)
        {
            if (Password.IsFocused)
            {
                if ((Password.Text.Length < 6) && (Password.IsFocused))
                {
                    ErrorMsg.IsVisible = true;
                    ErrorMsg.Text = "Invalid password!";
                    return;
                }
                else
                {
                    ErrorMsg.IsVisible = false;
                    ErrorMsg.Text = "";
                }
            }
        }

        private bool PasswordValidate(String Password)
        {
            var passwordText = Password;
            string strRegex = "/^[a - zA - Z0 - 9!@#]{6,8}$/";

            Regex regular = new Regex(strRegex);

            if (!(regular.IsMatch(passwordText)) || 
                !Regex.IsMatch(passwordText, "[A-Z]") || 
                !Regex.IsMatch(passwordText, "[a-z]") || 
                !Regex.IsMatch(passwordText, "[0-9]") || 
                !Regex.IsMatch(passwordText, "[!@#]"))
            {               
                return false;
            }
            else
            {
                return true;
            }
            //const string regexString = "/^[a - zA - Z0 - 9!@#]{6,8}$/";

            //bool IsValid = false;
            //IsValid = (Regex.IsMatch(e.NewTextValue, regexString, RegexOptions.IgnoreCase));
            //((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

            //if (!IsValid)
            //    lblPasswordValidation.Text = "Password is not valid"; // Put the label you want to set here
            //else
            //    lblPasswordValidation.Text = "";

        }

        private bool ValidationCompleted()
        {
            if (String.IsNullOrEmpty(Email.Text))
            {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Mobile number can't be empty !";
                return false;
            }
            else if (String.IsNullOrEmpty(Password.Text))
            {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Password can't be empty !";
                return false;
            }
            else if(!(Password.Text.Length < 6) || PasswordValidate(Password.Text))
            {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Password should contain 6 - 8 chars, 1 uppercase, 1 lowercase, 1 digit and any of !,@,# special chars!";
                return false;
            }
            else
            {
                ErrorMsg.IsVisible = false;
            }
            return true;
        }
    }
}