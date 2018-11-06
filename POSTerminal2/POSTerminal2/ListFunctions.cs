using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{
    public class ListFunctions
    { 
        internal static void ListDisplay(List<Product> list, int input)
        {
            if (input == 1)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"\n{item}\n");
                }
            }
            else if(input == 2)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"\n{item}" +
                        $"\nQuantity: {item.GetQuantity()}\n");
                }
            }
            else if(input == 3)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{list[i].GetItemID()}: {list[i].GetName()}");
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{list[i].GetName()} X {list[i].GetQuantity()}");
                }
            }

        }

        internal static double GetTotal(ref List<Product> ShoppingList, int input)
        {
            double sum = 0;
            foreach (var item in ShoppingList)
            {
                sum += item.GetPrice()*item.GetQuantity();
            }
            if(ShoppingList.Count == 0 && input == 2)
            {
                Console.Write("Cart Empty\n");
            }
            return sum;
        }

        internal static void KeywordDisplay(ref List<Product> Products, string search)
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

        internal static void AddItem(ref List<Product> ShoppingList, List<Product> Products)
        {
            string choice = "y";
            while(choice == "y")
            { 
                int Item = Validator.IndexValidator(Products,Validator.ReadLineMessage("Enter the number of the item you wish to purchase: "));
                foreach (var product in Products)
                {
                    if (product.GetItemID() == Item)
                    {
                        product.SetQuantity(Validator.QuantityValidator(Validator.ReadLineMessage("Enter a quantity: ")));
                        ShoppingList.Add(product);
                        Console.Write("\nItem added to cart!\n");
                    }
                }
                choice = Validator.Continuer("Would you like to add another item to your list? (y/n): ");
            }
        }

        internal static void RemoveItem(ref List<Product> ShoppingList)
        {
            string choice = "y";
            int Item;
            while (choice == "y")
            {
                Item = Validator.ItemIDValidator(ShoppingList, Validator.ReadLineMessage("Enter the number of the item you wish to remove: "));
                foreach (Product product in ShoppingList.ToList())
                {
                    if (product.GetItemID() == Item)
                    {
                        ShoppingList.Remove(product);
                    }
                }
                Console.Write("\nItem Removed!\n");
                choice = Validator.Continuer("Would you like to remove another item from your list? (y/n): ");
            }
        }
    }
}
