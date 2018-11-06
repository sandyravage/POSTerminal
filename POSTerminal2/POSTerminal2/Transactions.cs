using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{
    class TransactionValidator
    {
        public static string PaymentTypeValidator(string input)
        {
            while (input.ToLower() != "cash" && input.ToLower() != "credit" && input.ToLower() != "check")
            {
                Console.Write($"\nInvalid selection. Please choose between cash, credit, or check: ");
                input = Console.ReadLine();
            }
            return input;
        }

        
    }
}
