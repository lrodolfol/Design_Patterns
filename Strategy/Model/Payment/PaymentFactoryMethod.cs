using Strategy.Interface;

namespace Strategy.Model.Payment
{
    public abstract class PaymentFactoryMethod
    {
        public abstract IFormPayment FormPayment();
        public void CreatePayment()
        {
            var payment = FormPayment();
            Console.WriteLine($"Paying with: {payment.Pay()}");
        }
    }
}