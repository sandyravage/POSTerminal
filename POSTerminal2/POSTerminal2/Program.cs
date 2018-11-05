using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POSTerminal2
{
    class Program
    {
        public static List<Product> products = new List<Product>();
        public static List<Product> shoppingList = new List<Product>();
        public static string fileName = @"C:\Users\TEVERTS\source\repos\POSTerminal2\POSTerminal2\obj\Debug\products.txt";

        static void Main()
        {
            Console.Write("Welcome to Bangin' Beat Boutique!\n");
            ListAdder(FileReader(fileName), ref products);
            MainMenu();

        }

        public static string[] FileReader(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string text = reader.ReadToEnd();
                string[] textarr = text.Split(',');
                return textarr;
            }
        }

        public static void ListAdder(string[] textarr, ref List<Product> Products)
        {
            for (int i = 0; i < textarr.Length; i += 4)
            {
                Products.Add(new Product(textarr[i], textarr[i + 1], textarr[i + 2], double.Parse(textarr[i + 3])));
            }
        }

        public static void MainMenu()//adds options to access all other methods
        {
            Console.Write("Please enter a number corresponding to the following options:" +
                "\n1): View Entire List of Products" +
                "\n2): View List by Keyword" +
                "\n3): Add Item to Cart" +
                "\n4): Remove Item from Cart" +
                "\n5): View Cart" +
                "\n6): Checkout" +
                "\n7): Exit" +
                "\nEnter choice: ");
            switch (Validator.MenuValidator(Console.ReadLine()))
            {
                case "1":
                    Console.Clear();
                    ListFunctions.ListDisplay(ref products);
                    break;
                case "2":
                    Console.Clear();
                    ListFunctions.KeywordDisplay(ref products, Validator.ReadLineMessage("Enter a search term: "));
                    break;
                case "3":
                    Console.Clear();
                    ListFunctions.AddItem(ref shoppingList, products);
                    break;
                case "4":
                    Console.Clear();
                    ListFunctions.RemoveItem(ref shoppingList);
                    break;
                case "5":
                    Console.Clear();
                    ListFunctions.ListDisplay(ref shoppingList);
                    Console.Write($"\nCurrent total price: {ListFunctions.GetTotal(ref shoppingList)}\n");
                    break;
                case "6":

                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("\nThanks for shopping fam. Take it easy.");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Validator.Continue();
            Console.Clear();
            MainMenu();
        }
    }
}
