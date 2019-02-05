using System;
using System.Collections.Generic;
using System.Text;

namespace Attra.EWallet.Interface
{
    public interface RegistertionNotify
    {

        void onStartRegistration(string msg);
        void onCompleteRegistration();
        void onRegistrationSucces(String msg);
        void onRegistrationFail(String msg);
    }
}
