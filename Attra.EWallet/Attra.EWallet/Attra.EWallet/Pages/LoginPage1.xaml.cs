using Attra.EWallet.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1 : ContentPage
    {
       // public ObservableCollection<string> Items { get; set; }

            //new Comment

        public LoginPage1()
        {

            //Navigation.PushAsync(new LandingPage());
            //         InitializeComponent();

            //         Items = new ObservableCollection<string>
            //         {
            //             "Item 1",
            //             "Item 2",
            //             "Item 3",
            //             "Item 4",
            //             "Item 5"
            //         };

            //MyListView.ItemsSource = Items;

            //var vm = new LoginViewModel();
            //this.BindingContext = vm;
            //vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            //vm.RedirectHomePage += () =>   Navigation.PushModalAsync(new Page());
            InitializeComponent();

            //Email.Completed += (object sender, EventArgs e) =>
            //{
            //    Password.Focus();
            //};

            //Password.Completed +=  (object sender, EventArgs e) =>
            //{
            //   vm.SubmitCommand.Execute(null);
            //   // Navigation.RemovePage(this);
            //};
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
        //  //  var model = new LoginViewModel();
        //  //  this.BindingContext = model;
            
        //    if (Email.Text == "premananda.routray@attra.com.au" && Password.Text == "password")
        //    {
        //        await Navigation.PushModalAsync(new LandingPage());

        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "Invalid Login, try again", "OK");
                
        //    }
        }

    }
}
