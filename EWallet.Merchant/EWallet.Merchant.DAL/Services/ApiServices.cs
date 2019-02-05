using EWallet.Merchant.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Merchant.DAL.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterUser(string fName, string mobileNbr, int empid, string Email)
        {

            MerchantRegistration registration = new MerchantRegistration()
            {




            };


            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registration);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/merchants", content);
            return resposne.IsSuccessStatusCode;
        }
    }
}

