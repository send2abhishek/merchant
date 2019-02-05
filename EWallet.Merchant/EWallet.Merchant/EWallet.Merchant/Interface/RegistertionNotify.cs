using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Merchant.Interface
{
    public interface RegistertionNotify
    {

        void onStartRegistration();
        void onCompleteRegistration();
        void onRegistrationSucces(String msg);
        void onRegistrationFail(String msg);
    }
}
