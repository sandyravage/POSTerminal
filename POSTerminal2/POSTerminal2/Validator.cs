using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{
    class Validator
    {
        public static string YesNoChecker(string choice) //validates the many y/n decisions in this program
        {
            while (choice != "y" && choice != "n")
            {
                Console.Write("\nInvalid choice. Please enter \"y\" for yes or \"n\" for no: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        public static string MenuValidator(string input)
        {
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7")
            {
                Console.Write("\nInvalid choice. Please enter a decision 1 - 7: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static int IndexValidator(List<Product> Products, string input)
        {
            int newinput;
            while(!int.TryParse(input, out newinput) || newinput > Products.Count || newinput < 1)
            {             
                Console.Write($"\nInvalid selection. Please choose a number between 1 and {Products.Count}: ");
                input = Console.ReadLine();
            }
            return newinput;
        }

        public static string ReadLineMessage(string message)
        {
            Console.Write($"{message}");
            return Console.ReadLine();
        }

        public static void Continue()
        {
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

        public static string Continuer(string message)
        {
            Console.Write($"{message}");
            return YesNoChecker(Console.ReadLine());
        }

        public static int QuantityValidator(string input)
        {
            int newinput;
            while (!int.TryParse(input, out newinput) || newinput < 1)
            {
                Console.Write($"\nInvalid selection. Please choose a number greater than 0: ");
                input = Console.ReadLine();
            }
            return newinput;
        }

        public static int ItemIDValidator(List<Product> ShoppingList, string input)
        {
            int i = 0;
            int newinput;
            while (!int.TryParse(input, out newinput))
            {
                Console.Write($"\nInvalid selection. Please enter a number: ");
                input = Console.ReadLine();
            }
            while (true)
            {
                foreach (var product in ShoppingList)
                {
                    if (product.GetItemID() == newinput)
                    {
                        i++;
                    }
                }
                if (i == 0)
                {
                    Console.Write("\nInvalid selection. Please choose from ID(s) - ");
                    for (int j = 0; j < ShoppingList.Count; j++)
                    {
                        if (j < ShoppingList.Count - 1)
                        {
                            Console.Write($"{ShoppingList[j].GetItemID()}, ");
                        }
                        else
                        {
                            Console.Write($"{ShoppingList[j].GetItemID()}: ");
                        }
                    }
                    while (!int.TryParse(Console.ReadLine(), out newinput))
                    {
                        Console.Write($"\nInvalid selection. Please enter a number: ");
                    }
                    continue;
                }
                else if(i > 0)
                {
                    return newinput;
                }
            }
        }
    }
}
