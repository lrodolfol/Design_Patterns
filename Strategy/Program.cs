using Strategy;
using Strategy.Interface;
using Strategy.Model;
using Strategy.Model.Payment;

Console.WriteLine("====================");
Console.WriteLine("===DESIGN PATTERS===");
Console.WriteLine("====================");
Random random = new Random();
int op = 0;

//cria varios produtos para calcular o imposto
Products[] pdArry = {
    new Products{ Name="NoteBook Dell", Price = 2299.91 },
    new Products{ Name="NoteBook Lenovo", Price = 2564.05 },
    new Products{ Name="Macbook Air", Price = 6698.55 },
    new Products{ Name="Monitor Gamer Led", Price = 845.91 },
    new Products{ Name="Gaming Chair Razer", Price = 1561.85 },
    new Products{ Name="Gaming Chair Ocean", Price = 1025.22 },
    new Products{ Name="Mouse Bluetooth", Price = 167.90 },
    new Products{ Name="Mouse Pad Green", Price = 85.88 },
    new Products{ Name="Console XboxOne 1TB", Price = 2064.94 },
    new Products{ Name="Console PS5", Price = 4556.99 },
    new Products{ Name="Desktop Dell 2TB ", Price = 2200.00 },
    };

//todas as formas de pagamentos possiveis
PaymentFactoryMethod[] formPayent = {
        new PaymentMoney(),
        new PaymentCreditCard(),
        new PaymentPix()
    };

do
{
    Console.WriteLine("\n\n");
    //cria o orçamento com 2 produtos escolhidos de forma aleatoria
    Budget budget = new Budget
    {
        Products = new List<Products> {
            pdArry[random.Next(pdArry.Length)],
            pdArry[random.Next(pdArry.Length)]
        }
    };

    //dentro desse metodo que é feito o padrão Strategy
    budget.CalcBudget();

    //override do ToString() só para mostrar os produtos do orçamento
    Console.WriteLine(budget.ToString());

    //modo de pagamento aleatorio
    //aqui entra o padrão Factory Method
    var paidOut = budget.Pay(formPayent[random.Next(formPayent.Length)]);

    //se foi pago. faz varias outras tarefas
    //aqui entra o padrão Observer
    if(paidOut)
    {
        Console.WriteLine("Pago");
    }
    else
    {
        Console.WriteLine("Não pago");
    }

    op += 1;
    Console.ReadKey();

} while (op <= 3);