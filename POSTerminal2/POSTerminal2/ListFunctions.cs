using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{
    class ListFunctions
    {
        public static void ListDisplay(ref List<Product> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item}\n");
            }
        }

        public static double GetTotal(ref List<Product> ShoppingList)
        {
            double sum = 0;
            foreach (var item in ShoppingList)
            {
                sum += item.GetPrice();
            }
            if(ShoppingList.Count == 0)
            {
                Console.Write("\nCart Empty\n");
            }
            return sum;
        }

        public static void KeywordDisplay(ref List<Product> Products, string search)
        {
            Console.Clear();
            int i = 0;
            foreach (var item in Products)
            {
                if(item.ToString().ToLower().Contains(search.ToLower()))
                {
                    i++;
                    Console.WriteLine($"{item}\n");
                }
            }
            if (i == 0)
            {
                Console.Write("\nNo matches found\n");
            }
            else
            {
                Console.Write($"\nFound {i} matches\n");
            }
        }

        public static void AddItem(ref List<Product> ShoppingList, List<Product> Products)
        {
            string choice = "y";
            while(choice == "y")
            { 
                int Item = Validator.IndexValidator(Products,Validator.ReadLineMessage("Enter the number of the item you wish to purchase: "));
                foreach (var product in Products)
                {
                    if (product.GetItemID() == Item)
                    {
                        ShoppingList.Add(product);
                    }
                }
                choice = Validator.Continuer("Would you like to add another item to your list? (y/n): ");
            }
        }
        public static void RemoveItem(ref List<Product> ShoppingList)
        {
            string choice = "y";
            while (choice == "y")
            {
                int Item = Validator.IndexValidator(ShoppingList, Validator.ReadLineMessage("Enter the number of the item you wish to remove: "));
                foreach (var product in ShoppingList)
                {
                    if (product.GetItemID() == Item)
                    {
                        ShoppingList.Remove(product);
                    }
                }
                choice = Validator.Continuer("Would you like to remove another item from your list? (y/n): ");
            }
        }
    }
}
