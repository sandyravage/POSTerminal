using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POSTerminal2
{
    class Program //need to create music playing method, do validation for payments
    {
        public static List<Product> products = new List<Product>();
        public static List<Product> shoppingList = new List<Product>();
        public static string fileName = @"C:\Users\TEVERTS\source\repos\POSTerminal2\POSTerminal2\obj\Debug\products.txt";
        public static double total;
        public static string check;
        public static double cash;
        public static string cashString;
        public static string creditCard;

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
                    ListFunctions.ListDisplay(products,1);
                    SoundSampler.Caller(Validator.YesNoChecker(Validator.ReadLineMessage("Would you like to listen to a product? (y/n): ")),products);
                    break;
                case "2":
                    Console.Clear();
                    ListFunctions.KeywordDisplay(ref products, Validator.ReadLineMessage("Enter a search term: "));
                    break;
                case "3":
                    Console.Clear();
                    ListFunctions.ListDisplay(products, 3);
                    ListFunctions.AddItem(ref shoppingList, products);
                    break;
                case "4":
                    Console.Clear();
                    ListFunctions.ListDisplay(shoppingList, 3);
                    ListFunctions.RemoveItem(ref shoppingList);
                    break;
                case "5":
                    Console.Clear();
                    ListFunctions.ListDisplay(shoppingList,2);
                    Console.Write($"\nCurrent total price: ${ListFunctions.GetTotal(ref shoppingList,2):0.00}\n");
                    SoundSampler.Caller(Validator.YesNoChecker(Validator.ReadLineMessage("Would you like to listen to a product? (y/n): ")), shoppingList);
                    break;
                case "6":
                    Console.Clear();
                    string choice = Validator.Continuer("Are you sure you're ready to checkout? (y/n): ");
                    if (choice == "n")
                    {
                        break;
                    }
                    else if(shoppingList.Count == 0)
                    {
                        Console.Clear();
                        Console.Write("\nYou can't check out because your cart is empty!");
                        break;
                    }
                    else
                    {
                        Transactions.PaymentChoice(Transactions.PaymentTypeValidator(Validator.ReadLineMessage("Enter payment type - cash, credit, or check: ")));
                        Validator.Continue();
                        Console.Clear();
                        Console.Write("\nThank you for shopping today." +
                            "\nYour receipt is: \n");
                        ListFunctions.ListDisplay(shoppingList, 4);
                        Console.Write($"\nSubtotal: ${total}" +
                            $"\nTax: ${total*0.06:0.00}" +
                            $"\nGrand Total: ${total*0.06 + total:0.00}" +
                            $"\nYour payment info: {cashString}{creditCard}{check}");
                        Validator.Continue();
                        Environment.Exit(0);
                    }
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Thanks for shopping fam. Take it easy.");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            total = ListFunctions.GetTotal(ref shoppingList,1);
            Validator.Continue();
            Console.Clear();
            MainMenu();
        }
    }
}
