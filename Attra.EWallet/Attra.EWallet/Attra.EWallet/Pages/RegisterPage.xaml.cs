
﻿using Attra.EWallet.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Attra.EWallet.DAL.Services;
using System.Diagnostics;
using System.Net.Http;

namespace Attra.EWallet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        string passwordcomplexity = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

        

        private async void OnTapSignin(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.LoginPage());
        }

        public RegisterPage()
        {
            InitializeComponent();
            //this.BackgroundImage = "payee_reg_img.jpg";

            NavigationPage.SetHasNavigationBar(this, false);

            
        }

        

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

            else if (String.IsNullOrEmpty(entPassword.Text))
            {
                entPasswordError.IsVisible = true;
                entPasswordError.Text = "Password can't be empty !";
                return false;
            }

            else if (String.IsNullOrEmpty(entCnfPassword.Text))
            {
                entCnfPasswordError.IsVisible = true;
                entCnfPasswordError.Text = "Confirm Password can't be empty !";
                return false;
            }

            if (!((entPassword.Text.Trim()).Equals(entCnfPassword.Text.Trim())))
            {
                entCnfPasswordError.IsVisible = true;
                entCnfPasswordError.Text = "Password doesn't match with confirm password!";
                return false;
            }

            else
            {
                entEmpIdError.IsVisible = false;
                entPhNbrError.IsVisible = false;
                entEmailError.IsVisible = false;
                entNameError.IsVisible = false;
                entPasswordError.IsVisible = false;
                entCnfPasswordError.IsVisible = false;
                entCnfPasswordError.Text = "";
                entPasswordError.Text = "";
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





                DependencyService.Get<RegistertionNotify>().onStartRegistration("Attempting to Register User");


                bool RegistrationStatus=false;



                DAL.Services.ApiServices services = new DAL.Services.ApiServices();
                try
                {
                    RegistrationStatus = await services.RegisterUser(entName.Text, entPhNbr.Text.ToString(),
                      Int32.Parse(entEmpId.Text), entEmail.Text, entCnfPassword.Text.Trim());
                }

                catch (Exception ex) {

                    Debug.WriteLine(ex);

                    DependencyService.Get<RegistertionNotify>().onRegistrationFail("Server Down !");
                }



                //bool RegistrationStatus = true;


                if (RegistrationStatus)
                {

                    DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
                    DependencyService.Get<RegistertionNotify>().onRegistrationSucces("User Registered !");

                    ////await DisplayAlert("Hi", "User Registered...", "Okay");
                    await Navigation.PushAsync(new OtpVerify(entEmail.Text, entPhNbr.Text.ToString()));
                }
                else
                {
                    DependencyService.Get<RegistertionNotify>().onRegistrationFail("Something Went Wrong !");
                    DependencyService.Get<RegistertionNotify>().onCompleteRegistration();
                    //await DisplayAlert("Alert", "Something went wrong...", "Cancel");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            DisplayAlert("Terms And Conditions", "Terms And Conditions goes here", "Okay");
        }
    }
}