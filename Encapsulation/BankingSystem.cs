using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Deposit
    {
        public string DepositName { get; set; }
        public decimal MoneyAmount { get; set; }
    }
    public class User
    {
        private static int _innerId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Deposit [] Deposits { get; set; }
        public User(string name, string password)
        {
            Name = name;
            Id = ++_innerId;
            Deposits = new Deposit [3];
            Password = PasswordGenerator.GenerateSecretPassword(password);
        }
    }

    public static class Database
    {

    }

    public static class PasswordGenerator
    {
        public static string GenerateSecretPassword(string password)
        {
            string newString = "";
            for(int i = 0; i < password.Length; i++)
            {
                int ascii = (int) password[i];
                ascii++;
                newString += (char)(ascii);
            }
            return newString;
        }
    }

    public static class SmsSender
    {
        private static HttpClient httpClient = new HttpClient();
        public static string SendSms(string phoneNumber, string text)
        {
            string _mobizonApiKey = "3098eaf41ba2e95f9e7c40262088d52e643eec0d";
            var values = new Dictionary<string, string>
            {
               { "apiKey", _mobizonApiKey },
               { "recipient", phoneNumber },
               {"text", text }
            };
            var content = new FormUrlEncodedContent(values);
            var response = httpClient.PostAsync("https://api.mobizon.com/service/Message/SendSMSMessage", content);
            return response.Result.Content.ReadAsStringAsync().Result;
        }

    }
}
