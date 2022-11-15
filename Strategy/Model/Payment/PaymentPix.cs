using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model.Payment
{
    public class PaymentPix : PaymentFactoryMethod
    {
        public override IFormPayment FormPayment()
        {
            return new Pix();
        }
    }
}
