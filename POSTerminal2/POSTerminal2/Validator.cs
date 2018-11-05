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
        
        public static DateTime DateValidator()
        {
            DateTime datetime;
            string input = Console.ReadLine();
            while (!DateTime.TryParse(input,out datetime))
            {
                Console.Write("Invalid input. Please enter date in mm/dd/yyyy format: ");
                input = Console.ReadLine();
            }
            return datetime;
        }

        public static int IndexValidator(List<Product> Products, string input)
        {
            int newinput;
            while(!int.TryParse(input, out newinput))
            {
                while (newinput > Products.Count - 1 || newinput < 1)
                {
                    Console.Write($"\nInvalid selection. Please choose a number between 1 and {Products.Count}: ");
                    input = Console.ReadLine();
                    break;
                }
            }
            return newinput - 1;
        }

        public static string ReadLineMessage(string message)
        {
            Console.Write($"{message}\n");
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
    }
}
