using Strategy.Interface;

namespace Strategy.Model.Payment
{
    public abstract class PaymentFactoryMethod
    {
        public abstract IFormPayment FormPayment();
        public IFormPayment CreatePayment()
        {
            var payment = FormPayment;
            //Console.WriteLine($"\nPaying with: {payment.Pay()}");
            return payment();
        }
    }
}