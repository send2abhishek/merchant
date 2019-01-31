using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Attra.EWallet.ViewModels
{
   public class LoginViewModel:INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public  Action  RedirectHomePage;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {

            //some comments
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
               // PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            //SubmitCommand = new Command(OnSubmit);
        }
        //public void OnSubmit()
        //{
        //    if (email != "premananda.routray@attra.com.au" || password != "password")
        //    {
        //        DisplayInvalidLoginPrompt();
        //    }
        //    else
        //    {
        //         RedirectHomePage();
        //    }
            
        //}
    }
}
