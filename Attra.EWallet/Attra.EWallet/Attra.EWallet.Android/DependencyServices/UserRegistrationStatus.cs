using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Attra.EWallet.Droid.DependencyServices;
using Attra.EWallet.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserRegistrationStatus))]

namespace Attra.EWallet.Droid.DependencyServices
{
    public class UserRegistrationStatus : RegistertionNotify
    {

        private ProgressDialog progressDialog = new ProgressDialog(MainActivity.Instance);






        public void onStartRegistration()
        {

            progressDialog.SetMessage("Attempting to Register User");
            progressDialog.SetTitle("Please Wait...");
            progressDialog.SetCancelable(false);
            progressDialog.Show();
        }
        public void onCompleteRegistration()
        {

            progressDialog.Dismiss();


        }

        public void onRegistrationSucces(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short).Show();
        }

        public void onRegistrationFail(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short).Show();
        }
    }
}