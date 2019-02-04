﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OtpVerfiyPopUp 
	{
		public OtpVerfiyPopUp ()
		{
			InitializeComponent ();
		}

        private async void OnTapValidate(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreatePswdPage());  
        }


    }
}