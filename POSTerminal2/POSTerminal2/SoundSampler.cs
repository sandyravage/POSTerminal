using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace POSTerminal2
{
    class SoundSampler
    {
        public static void Player(int input)
        {
            SoundPlayer player = new SoundPlayer($@"C:\Users\TEVERTS\source\repos\POSTerminal2\{input}.wav");
            player.Play();
            Validator.Continue();
            player.Stop();
        }

        public static void Caller(string input, List<Product> list)
        {
            while(input == "y")
            {
                Player(Validator.ItemIDValidator(list, Validator.ReadLineMessage("Enter a product ID you wish to listen to: ")));
                Console.Write("\nDo you wish to listen to another product? (y/n): ");
                input = Validator.YesNoChecker(Console.ReadLine());
            }

        }
    }
}
