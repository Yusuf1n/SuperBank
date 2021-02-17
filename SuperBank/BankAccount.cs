using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBank 
{
    class BankAccount
    {
        public long Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }

        List<decimal> accountDeposits = new List<decimal>();
        List<decimal> accountWithdrawals = new List<decimal>();

        public void MakeDeposit()
        {
            Console.Write("\nEnter an amount you would like to deposit: £");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            if (depositAmount <= 0)
            {
                //throw new ArgumentOutOfRangeException(nameof(depositAmount), "Amount of deposit must be positive");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDeposit amount must be positive");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Balance += depositAmount;
                accountDeposits.Add(depositAmount);
                Console.WriteLine($"Amount of deposits into the account {Number}: " + accountDeposits.Count);
                Console.WriteLine("Account balance: £" + Balance);
            }
        }

        public void MakeWithdrawal()
        {
            Console.Write("\nEnter an amount you would like to withdraw: £");
            decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
            if (withdrawalAmount <= 0)
            {
                //throw new ArgumentOutOfRangeException(nameof(withdrawalAmount), "Amount of withdrawal must be positive");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWithdrawal amount must be positive");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Balance - withdrawalAmount < 0)
            {
                //throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNot sufficient funds for this withdrawal");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Balance -= withdrawalAmount;
                accountWithdrawals.Add(withdrawalAmount);
                Console.WriteLine($"Amount of withdrawals from the account {Number}: " + accountWithdrawals.Count);
                Console.WriteLine("Account balance: £" + Balance);
            }
        }

        public string GetAccountHistory()
        {
            var depositReport = new StringBuilder();
            var withdrawalReport = new StringBuilder();
            Console.WriteLine("\nAccount Transactions:");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nAccount Deposits");

            //HEADER
            depositReport.AppendLine("\nDate\t\tAmount");
            foreach (var deposit in accountDeposits)
            {
                //ROWS
                //Console.WriteLine($"£{deposit}");
                depositReport.AppendLine($"{DateTime.Now.ToString("mm/dd/yy")}\t £{deposit}");
            }
            Console.WriteLine(depositReport.ToString());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAccount Withdrawals");

            //HEADER
            withdrawalReport.AppendLine("\nDate\t\tAmount");
            foreach (var withdrawal in accountWithdrawals)
            {
                //ROWS
                //Console.WriteLine($"£{withdrawal}");
                withdrawalReport.AppendLine($"{DateTime.Now.ToString("mm/dd/yy")}\t £{withdrawal}");
            }
            Console.WriteLine(withdrawalReport.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nAccount Balance is: £" + Balance);
            return null;
        }
    }
}
