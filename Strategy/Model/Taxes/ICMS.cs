using Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Model
{
    internal class ICMS : ITax
    {
        public double CalculaImposto(Budget budget)
        {
            var total = (from tot in budget.Products
                         select tot).Sum(e => e.Price);

            return total * 0.07;   
        }
    }
}
