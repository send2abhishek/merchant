using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Attra.EWallet.Models;
namespace Attra.EWallet.Data
{
    public class MenuData : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotityPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<MasterMenuItem> MainMenuItems { get; set; }

        public MenuData()
        {

        }

        private void LoadMenuItems()
        {
            MainMenuItems = new ObservableCollection<MasterMenuItem>()
            {
                //new mastermenuitem{navigationid=1,text="detail page",icon="",classname="pages.mainview.mainmenudetail"},
                // new mastermenuitem{navigationid=1,text="logout",icon="",classname=""}
            };
        }
    }
}
