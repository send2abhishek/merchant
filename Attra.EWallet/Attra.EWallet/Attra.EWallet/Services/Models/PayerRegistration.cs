using System;
using System.Collections.Generic;
using System.Text;

namespace Attra.EWallet.Services.Models
{
    public class PayerRegistration
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public int empId { get; set; }
        public string realm { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool emailVerified { get; set; }
    }
}
