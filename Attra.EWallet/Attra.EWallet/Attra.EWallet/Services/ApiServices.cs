using Attra.EWallet.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attra.EWallet.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterUser(string fName, string mobileNbr, int empid, string Email)
        {

            PayerRegistration registration = new PayerRegistration()
            {

                firstName = fName,
                lastName = "null",
                mobile = mobileNbr,
                empId= empid,
                realm="Payer",
                username= empid.ToString(),
                email= Email,
                password = "Default_pass",
                emailVerified=true,


            };


            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registration);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers", content);
            return resposne.IsSuccessStatusCode;
        }
    }
}
