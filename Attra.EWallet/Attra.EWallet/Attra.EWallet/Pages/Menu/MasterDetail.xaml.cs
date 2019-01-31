using Attra.EWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet.Pages.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
	{
        public MasterDetail()
        {
            InitializeComponent();
            

             masterpage.ListView.ItemSelected += OnItemSelected;      
        }
        private  void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if(item!=null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterpage.ListView.SelectedItem = null;
                
                IsPresented = false;
                //await Navigation.PushModalAsync(Detail);
                // Detail.Navigation.PopModalAsync();
            }
        }
    }
}