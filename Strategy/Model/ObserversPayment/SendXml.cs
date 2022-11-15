using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
