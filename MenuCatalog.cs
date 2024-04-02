using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_UML2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas)
            {
                Console.WriteLine(p);
            }

        }

        public Pizza GetPizzaByNumber(int number)
        {
            foreach (Pizza p in _pizzas)
            {
                if (p.Number == number) return p;
            }
            return null;
        }

        public Pizza GetPizzaByName(string criteria)
        {
            foreach (Pizza p in _pizzas)
            {
                if (p.Name == criteria) return p;
            }
            return null;
        }

        public void Update(Pizza updatedPizza)
        {
            Pizza pizza = GetPizzaByNumber(updatedPizza.Number);
            pizza.Name = updatedPizza.Name;
            pizza.Price = updatedPizza.Price;
        }

        public void Delete(int number)
        {
            List<Pizza> updatedList = new List<Pizza>();

            foreach (Pizza p in _pizzas)
            {
                if (p.Number != number)
                {
                    updatedList.Add(p);
                }
            }
            _pizzas = updatedList;

        }



    }
}
