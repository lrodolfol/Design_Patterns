using Strategy.Interface;
using Strategy.Model.Payment.Payment;

namespace Strategy.Model.Payment
{
    public class PaymentMoney : PaymentFactoryMethod
    {
        public override IFormPayment FormPayment()
        {
            return new Money();
        }
    }
}
