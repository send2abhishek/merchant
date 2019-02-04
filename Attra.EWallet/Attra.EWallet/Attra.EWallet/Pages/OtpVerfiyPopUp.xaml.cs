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
	public partial class OtpVerfiyPopUp 
	{

        public static BindableProperty PinProperty = BindableProperty.
        Create("Pin", typeof(string), typeof(OtpVerfiyPopUp), defaultBindingMode: BindingMode.OneWayToSource);

        public string Pin
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
        public OtpVerfiyPopUp ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
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

<<<<<<< HEAD
            PopupNavigation.Instance.PopAsync(true);
=======
        private async void OnTapValidate(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreatePswdPage());  
        }

>>>>>>> 4d51a25222868ec144393f5f195354a9b7ac8a55

        }
    }
}