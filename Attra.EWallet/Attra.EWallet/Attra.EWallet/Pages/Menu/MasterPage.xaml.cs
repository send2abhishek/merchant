using Attra.EWallet.Pages.DetailViews;
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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView{get{ return listview; } }
        public List<Models.MasterMenuItem> items;
		public MasterPage ()
		{
			InitializeComponent ();
            SetItems();

        }
        
        void SetItems()
        {
            items = new List<Models.MasterMenuItem>();
            items.Add(new Models.MasterMenuItem("InfoScreen1", "icons8_contact.png", Color.White, typeof(InfoScreen1)));
            items.Add(new Models.MasterMenuItem("InfoScreen2", "money_bag.png", Color.White, typeof(TranHistoryPage)));
            ListView.ItemsSource = items;

        }
    }
}