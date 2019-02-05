using Attra.EWallet.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attra.EWallet.DAL.Services
{
  public class ApiServices
    {

        public async Task<bool> RegisterUser(string fName, string mobileNbr, int empid, string Email,string Passsword)
        {

            PayerRegistration registration = new PayerRegistration()
            {

                firstName = fName,
                lastName = "null",
                mobile = mobileNbr,
                empId = empid,
                realm = "Payer",
                username = mobileNbr.ToString(),
                email = Email,
                password = Passsword,
                emailVerified = true,


            };


            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registration);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers", content);
            return resposne.IsSuccessStatusCode;
        }


        public async Task<OtpResponse> ValidateOtp(double Otp, string Email, string phnbr)
        {

            OtpValidate validate=new OtpValidate()
            {

                OTP= Otp,
                email= Email,
                mobileNumber= phnbr


            };


            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(validate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers", content);
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers/confirmOTP", content);

            var jsonString = await resposne.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OtpResponse>(jsonString);
        }


        public async Task<bool> ReSendOtpOtp(string Email, string phnbr)
        {

            ReSendOtp validate = new ReSendOtp()
            {

                
                email = Email,
                mobileNumber = phnbr


            };


            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(validate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers", content);
            var resposne = await httpClient.PostAsync("http://ec2-13-127-1-106.ap-south-1.compute.amazonaws.com:4000/api/payers/resendOTP", content);


            return resposne.IsSuccessStatusCode;
        }
    }
}
