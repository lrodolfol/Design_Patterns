using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Interface
{
    //ja que houve a necessidade de implementar o padrão decorator
    //a interface passou a ser uma classe abstrata
    //para facilitar a instanciação das classes concretas, optei em deixar um construtor que recebe um adicional
        //e um construtor vazio. assim nao preciso sempre passar null (caso houvesse só 1 construct)
    public abstract class ITax
    {
        protected ITax aditionalTax;
        public ITax(ITax adicionalTax)
        {
            this.aditionalTax = adicionalTax;
        }
        public ITax()
        {
        }
        public abstract double CalculaImposto(Budget orcamento);

        public double calculaImpostosDecorator(Budget budget)
        {
            double total = CalculaImposto(budget);
            if(aditionalTax != null)
            {
                total += aditionalTax.CalculaImposto(budget);
            }

            return total;
        }
    }
}
