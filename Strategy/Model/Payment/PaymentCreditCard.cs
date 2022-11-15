using Strategy.Interface;
using Strategy.Model.Payment.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model.Payment
{
    public class PaymentCreditCard : PaymentFactoryMethod
    {
        public override IFormPayment FormPayment()
        {
            return new CreditCard();
        }
    }
}
