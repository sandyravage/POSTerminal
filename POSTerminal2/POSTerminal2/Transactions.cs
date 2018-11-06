using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace POSTerminal2
{
    public class Transactions
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

        public static double CashReturn(string input)
        {
            double newinput;
            while (!double.TryParse(input, out newinput) || newinput < Program.total*0.06 + Program.total)
            {
                Console.Write($"\nInvalid selection. Please enter cash greater than {Program.total*0.06 + Program.total}: ");
                input = Console.ReadLine();
            }
            Console.Write($"\nCash received");
            return newinput;
        }

        public static string CardReturn(string input)
        {
            string number = input;
            string expiration;
            string CVV;
            Console.Write("\nPlease enter an expiration number: ");
            expiration = Console.ReadLine();
            Console.Write("\nPlease enter a CVV number: ");
            CVV = Console.ReadLine();
            while(!Regex.IsMatch(number, @"^[0-9]{4}[-][0-9]{4}[-][0-9]{4}[-][0-9]{4}$"))
            {
                Console.Write($"\nInvalid selection. Please enter credit card number in format ####-####-####-####: ");
                number = Console.ReadLine();
            }
            while (!Regex.IsMatch(expiration, @"^[0-9]{2}[/][0-9]{4}$"))
            {
                Console.Write($"\nInvalid selection. Please enter expiration date in format MM/YYYY: ");
                expiration = Console.ReadLine();
            }
            while (!Regex.IsMatch(CVV, @"^[0-9]{3}$"))
            {
                Console.Write($"\nInvalid selection. Please enter three digit CVV number: ");
                CVV = Console.ReadLine();
            }
            Console.Write("\nCredit card confirmed.");
            return $"Card Number: {number}" +
                $"\nExpiration Date: {expiration}" +
                $"\nCVV: {CVV}";
        }

        public static string CheckReturn(string input)
        {
            string routingNumber = input;
            string accountNumber;
            string checkNumber;
            Console.Write("\nEnter an account number: ");
            accountNumber = Console.ReadLine();
            Console.Write("\nEnter a check number: ");
            checkNumber = Console.ReadLine();
            while (!Regex.IsMatch(routingNumber, @"^[0-9]{9}$"))
            {
                Console.Write($"\nInvalid selection. Please enter your nine digit routing number: ");
                routingNumber = Console.ReadLine();
            }
            while (!Regex.IsMatch(accountNumber, @"^[0-9]+$"))
            {
                Console.Write($"\nInvalid selection. Please enter an account number: ");
                accountNumber = Console.ReadLine();
            }
            while (!Regex.IsMatch(checkNumber, @"^[0-9]+$"))
            {
                Console.Write($"\nInvalid selection. Please enter a check number: ");
                checkNumber = Console.ReadLine();
            }
            Console.Write("\nCredit card confirmed.");
            return $"Routing Number: {routingNumber} " +
                $"\nAccount Number: {accountNumber} " +
                $"\nCheck Number: {checkNumber}";
        }

        public static void PaymentChoice(string input)
        {
            if(input.ToLower() == "cash")
            {
                Program.cash = CashReturn(Validator.ReadLineMessage("Enter a cash amount: "));
                Program.cashString = $"Cash Amount Paid: ${Program.cash:0.00} Change: ${Program.cash - Program.total:0.00}";
            }
            else if (input.ToLower() == "check")
            {
                Program.check = CheckReturn(Validator.ReadLineMessage("Enter a check number: "));
            }
            else
            {
                Program.creditCard = CardReturn(Validator.ReadLineMessage("Enter a credit card number: "));
            }
        }


    }
}
