using Strategy.Model;
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
            
            return stringBudget.ToString();
        }

        public double CalcBudget()
        {
            double total = (
                new COFINS().CalculaImposto(this) +
                new ICMS().CalculaImposto(this) +
                new IPI().CalculaImposto(this) +
                new ISS().CalculaImposto(this)
                );

            return total;
        }
    }
}
