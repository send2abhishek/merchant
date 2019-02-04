using Attra.EWallet.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Attra.EWallet.DAL.Services
{
   public class LoginApi
    {
        public async System.Threading.Tasks.Task<bool> LoginUserDetails(string Email, string Password)
        {
            LoginUser user = new LoginUser()
            {
                //MobileNo = Mobile,
                email = Email,
                password = Password,
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers/login", content);
            Console.WriteLine(resposne);
            return resposne.IsSuccessStatusCode;

        }
    }
}
