using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model.Payment.Payment
{
    public class Money : IFormPayment
    {
        public bool Pay()
        {
            Console.WriteLine("\nPayment with Money\n");
            return true;
        }
    }
}
