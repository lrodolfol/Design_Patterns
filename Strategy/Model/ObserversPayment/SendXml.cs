using Strategy.Interface;

namespace Strategy.Model.ObserversPayment
{
    public class SendXml : IObserver
    {
        public void Run(Budget budget)
        {
            Console.WriteLine("The XML Notification for budget Nº {0:D4} is complete", budget.CodOrcamento);
        }
    }
}
