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
    public partial class RegisterPage : ContentPage
    {

        public static BindableProperty PinProperty = BindableProperty.
        Create("Pin", typeof(string), typeof(RegisterPage), defaultBindingMode: BindingMode.OneWayToSource);

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
        public RegisterPage()
        {
            InitializeComponent();
            //this.BackgroundImage = "background_screen_two.png";

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

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            
            

            if (entPhNbr.IsFocused)
            {

                if ((!(entPhNbr.Text.Length >= 10)) && (entPhNbr.IsFocused))
                {

                    entPhNbrError.IsVisible = true;
                    entPhNbrError.Text = "Invalid Mobile Number !";

                }

                else
                {
                    entPhNbrError.IsVisible = false;
                    entPhNbrError.Text = "";
                }

            }

            
            
            

        }

        private void EntPhNbr_Unfocused(object sender, FocusEventArgs e)
        {

            if (!(entPhNbr.IsFocused))
            {
                entPhNbrError.IsVisible = false;
                entPhNbrError.Text = "";
            }
            
        }

        
    }
}