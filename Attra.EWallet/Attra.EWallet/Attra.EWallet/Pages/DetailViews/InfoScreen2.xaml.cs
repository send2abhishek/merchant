using Attra.EWallet.Pages.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attra.EWallet.Pages.DetailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoScreen2 : ContentPage
	{
       
		public InfoScreen2 ()
		{
			InitializeComponent ();
            // NavigationPage.SetHasBackButton(this, true);
            //MasterDetail page = new MasterDetail();
            //NavigationPage.SetHasBackButton(page, true);
        }

        
	}
}