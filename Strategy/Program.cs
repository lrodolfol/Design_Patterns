using Strategy;
using Strategy.Model;

Console.WriteLine("PADRÃO STRATEGY");
Console.WriteLine("===============\n\n");
Random random = new Random();

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

Budget budget = new Budget
{
    Products = new List<Products> {
            pdArry[random.Next(pdArry.Length)],
            pdArry[random.Next(pdArry.Length)]
    }
};
Console.WriteLine(budget.ToString());

double totalBudget = budget.CalcBudget();

Console.WriteLine("The budget total is: {0:C}", totalBudget);