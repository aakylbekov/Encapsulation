using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Account
    {
        // Fields
        public decimal CurrentSum;
        private string _secretCode = "123*";

        // Properties

        #region Very New Way
        public string HolderName { get; set; }
        #endregion

        #region New Way
        public string SecretCode {
            get
            {
                return _secretCode;
            }
            set
            {
                if (IsValidPassword(value))
                    { _secretCode = value;  }
            }
        }
        #endregion

        #region Old Way
        public string GetSecretCode()
        {
            Console.WriteLine("Somebody accessed secret key");
            Console.WriteLine("This method sends SMS");

            return _secretCode;
        }

        // Password must contain at least one sign '*', '#'
        // Password's length must be exactly 4     
        public void SetSecretCode(string setValue)
        {
            if (IsValidPassword(setValue))
            {
                _secretCode = setValue;
                Console.WriteLine("Password was changed");
            }
            else
            {
                Console.WriteLine("Password was NOT updated. Not passed validation rules");
            }
            return;               
        }
        #endregion
        private bool IsValidPassword(string passwordToCheck)
        {
            return ((passwordToCheck.Contains('*') || passwordToCheck.Contains('#'))
                && passwordToCheck.Length == 4);
        }
        public Account()
        {
            Console.WriteLine(HolderName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Account a = new Account();

            ////a.SecretCode = "123adfawd";
            ////Console.WriteLine(a.SecretCode);

            //BankDeposit[] deposits = new BankDeposit[]
            //{
            //    new BankDeposit()
            //    {
            //        HolderName = "Alfar",
            //        SumInTg = 1000000M,
            //    },
            //    new BankDeposit()
            //    {
            //        HolderName = "Fazliddin",
            //        SumInTg = -100M
            //    },
            //    new BankDeposit()
            //    {
            //        HolderName = "Maxim",
            //        SumInTg = 100000M
            //    },
            //    new BankDeposit()
            //    {
            //        HolderName = "Anastasiya",
            //        SumInTg = 10000M
            //    }
            //};

            //Console.WriteLine("Enter new converter ratio");
            //decimal ratioOld = Convert.ToDecimal(Console.ReadLine());
            //BankDeposit.BaseConvertFormat = ratioOld;

            //foreach (var item in deposits)
            //{
            //    item.ShowMySumInTg();
            //}

            //Console.WriteLine("Enter new converter ratio");
            //BankDeposit.BaseConvertFormat = ratioOld;

            var result = SmsSender.SendSms("77777730111", "Fazliddin invites you to date");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
