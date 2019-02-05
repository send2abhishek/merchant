using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Merchant.DAL.Models
{
    public class MerchantRegistration
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string mobile { get; set; }
        public string realm { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool emailVerified { get; set; }

    }
}
