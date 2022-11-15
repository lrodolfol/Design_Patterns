using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model.Payment.Payment
{
    public class CreditCard : IFormPayment
    {
        public string Pay()
        {
            return "Credit Card";
        }
        
    }
}
