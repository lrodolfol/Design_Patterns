using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model.Payment
{
    public class Pix : IFormPayment
    {
        public bool Pay()
        {
            Console.WriteLine("\nPayment with Pix\n");
            return false;
        }
    }
}
