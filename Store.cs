using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace VS_UML2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            List<Pizza> list = new List<Pizza>()
            {
                new Pizza() { Number = 1, Name = "Margherita", Price = 80 },
                new Pizza() { Number = 2, Name = "Vesuvio", Price = 92 },
                new Pizza() { Number = 3, Name = "Capricciosa", Price = 98 },
                new Pizza() { Number = 4, Name = "Calzone", Price = 98 },
            };

            foreach (Pizza item in list)
            {
                menuCatalog.Create(item);
            }


            menuCatalog.PrintMenu();

            

            /*Console.WriteLine();
            int pizzaToBeFound = 2;
            Console.WriteLine($"Finding Pizza {pizzaToBeFound}");
            Pizza foundPizza = menuCatalog.GetPizzaByNumber(pizzaToBeFound);
            Console.WriteLine(foundPizza);

            Console.WriteLine();
            string searchCriteria = "PIZZA#1";
            Console.WriteLine($"Finding Pizza starting with: {searchCriteria}");
            foundPizza = menuCatalog.GetPizzaByName(searchCriteria);
            Console.WriteLine(foundPizza);

            /*Console.WriteLine();
            Console.WriteLine($"Updating Pizza #{foundPizza.Number}");
            foundPizza.Name += " (Updated)";
            menuCatalog.Update(foundPizza);

            Console.WriteLine();
            menuCatalog.PrintMenu();

            Console.WriteLine();
            int pizzaToBeDeleted = 2;
            Console.WriteLine($"Deleting pizza#: {pizzaToBeDeleted}");
            menuCatalog.Delete(pizzaToBeDeleted);
            Console.WriteLine();
            menuCatalog.PrintMenu();*/

        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();
        }
    }
}
