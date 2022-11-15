using Strategy.Interface;
using Strategy.Model;
using Strategy.Model.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Budget
    {
        public static int _codigo { get; set; }

        public int CodOrcamento { get; set; }
        public IList<Products> Products;
        public double totalTax { get; set; }

        public Budget()
        {
            _codigo += 1;
            CodOrcamento = _codigo++;
        }

        public override string ToString()
        {
            StringBuilder stringBudget = new StringBuilder();
            stringBudget.Append("The Budget is: \n");

            foreach (var product in Products)
            {
                stringBudget.Append($"{product.Name} costing R$ {product.Price}\n");
            }

            stringBudget.Append($"\nThe total Tax is: R$ {this.totalTax}");

            return stringBudget.ToString();
        }

        public void CalcBudget()
        {
            //ao inves de ficar vendo imposto por imposto fazendo varios if para cada calculo,
            //já tenho uma interface com um metodo que é implementada em cada classe a seguir
            //cada classe tem sua regra de negócio especifica
            double total = (
                new COFINS().CalculaImposto(this) +
                new ICMS().CalculaImposto(this) +
                new IPI().CalculaImposto(this) +
                new ISS().CalculaImposto(this)
                );

            totalTax = total;
        }

        public bool Pay(PaymentFactoryMethod formOfPayment)
        {
            //não há necessidade de saber qual a exata forma de pagamento
            //essa tarefa será feito pela factory de cada classe concreta. (PaymentFactoryMoney, Creditcard e pix)
            //e o objeto(produto) será retornado corretamente de acordo com o tipo escolhido
            IFormPayment formOfpayment = formOfPayment.CreatePayment();
            var paidOut = formOfpayment.Pay();

            return paidOut;
        }
    }
}
