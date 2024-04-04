using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_UML2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza GetPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("|     Enter Pizza     |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("|     PIZZAMENU     |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new pizza",
                "2. Print menu",
                "3. Search function",
                "4. Update Pizza",
                "5. Delete Pizza"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza newPizza = GetPizza();
                            _menuCatalog.Create(newPizza);
                            Console.WriteLine($"You created: {newPizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        _menuCatalog.PrintMenu();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine($"You selected: {mainMenulist[MenuChoice]}");
                        Console.WriteLine($"Enter a number or a name of a pizza: ");

                        string input = Console.ReadLine();
                        Pizza pizza = null;

                        try
                        {
                            int number = Int32.Parse(input);
                            pizza = _menuCatalog.GetPizzaByNumber(number);
                        }
                        catch (FormatException e)
                        {
                            if(_menuCatalog.GetPizzaByName != null)
                            {
                                pizza = _menuCatalog.GetPizzaByName(input);
                            }

                            else
                            {
                                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                            }
                            
                            
                        }
                        if (pizza != null)
                        {
                            Console.WriteLine($"You found: {pizza}");
                        }

                        else
                        {
                            Console.WriteLine("Pizza not found");
                        }


                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    case 4:
                        try
                        {
                            Pizza updatePizza = GetPizza();
                            _menuCatalog.Update(updatePizza);
                            _menuCatalog.PrintMenu();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza updated");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine($"Enter a number of a pizza: ");
                        string deleteInput = Console.ReadLine();
                        try
                        {
                            
                            int number = Int32.Parse(deleteInput);
                            _menuCatalog.Delete(number);
                            _menuCatalog.PrintMenu();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not delete pizza");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;



                }
            }
        }
    }
}
