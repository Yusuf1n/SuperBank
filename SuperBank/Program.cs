using System;
using System.Threading;

namespace SuperBank
{
    class Program
    { 
        static void Main(string[] args)
        {
            var account = new BankAccount();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\tWelcome to the Super Bank!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nTo get started please enter your full name: ");
            account.Owner = Console.ReadLine();

            Console.Write($"\nHi {account.Owner}, please enter your 10 digit account number: ");
            account.Number = long.Parse(Console.ReadLine());

            for (int i = 1; i > 0; i++)
            {
                if (account.Number.ToString().Length == 10)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAccount Number must be 10 digits long");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nPlease try again: ");
                    account.Number = long.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine($"\nAccount {account.Number} was created for {account.Owner} with £{account.Balance}");

            for (int i = 1; i > 0; i++)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. Make a deposit");
                Console.WriteLine("2. Make a withdrawal");
                Console.WriteLine("3. Retrieve account history");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your option (1-4): ");

                int option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        account.MakeDeposit();
                        break;

                    case 2:
                        account.MakeWithdrawal();
                        break;

                    case 3:
                        account.GetAccountHistory();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nThank you for using the Super Bank :)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlease choose a valid option from the main menu");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            Console.ReadLine();


            // Test for a negative balance.
            //try
            //{
            //    account.MakeWithdrawal();
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}
        }
    }
}

