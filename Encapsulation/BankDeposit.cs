using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class BankDeposit
    {
        public string HolderName { get; set; }
        public decimal SumInTg { get; set; }
        public static decimal BaseConvertFormat { get; set; }
        public static void StaticMethodExample()
        {
            Console.WriteLine(BaseConvertFormat);
        }
        public void ShowMySumInTg()
        {
            if(SumInTg < 0)
            {
                Console.WriteLine(SumInTg);
            }
            else Console.WriteLine(SumInTg * BaseConvertFormat);
        }
        public BankDeposit()
        {
        }
    }

}
