using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{
    class ListFunctions
    {
        public static void ListDisplay(ref List<Product> Products)
        {
            foreach (var item in Products)
            {
                Console.WriteLine($"{item}\n");
            }
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
    }
}
