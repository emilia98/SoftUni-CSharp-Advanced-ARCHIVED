using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    public class StartUp
    {
        private static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        static void Main(string[] args)
        {
            string command = String.Empty;

            while((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ');
                string[] restArgs = commandArgs.Skip(1).ToArray();

                string commandName = commandArgs[0];

                switch(commandName)
                {
                    case "Create":
                        Create(restArgs);
                        break;
                    case "Deposit":
                        Deposit(restArgs);
                        break;
                    case "Withdraw":
                        Withdraw(restArgs);
                        break;
                    case "Print":
                        Print(restArgs);
                        break;
                }
            }
        }


        public static void Create(string[] args)
        {
            /*
            if(args.Length == 0)
            {
                throw new Exception("Not enough paramaters");
            }
            */

            int accId = int.Parse(args[0]);

            if(accounts.ContainsKey(accId))
            {
                Console.WriteLine("Account already exists");
                return;
            }

            BankAccount acc = new BankAccount();
            acc.Id = accId;

            accounts.Add(accId, acc);
        }

        public static void Deposit(string[] args)
        {
            /*
            if(args.Length < 2)
            {
                throw new Exception("Not enough parameters...");
            }
            */

            int accId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            if(accounts.ContainsKey(accId))
            {
                accounts[accId].Deposit(amount);
                return;
            }

            Console.WriteLine("Account does not exist");
        }

        public static void Withdraw(string[] args)
        {
            /*
            if(args.Length < 2)
            {
                throw new Exception("Not enough parameters...");
            }
            */

            int accId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);


            if(accounts.ContainsKey(accId))
            {
                BankAccount acc = accounts[accId];

                if(acc.Balance >= amount)
                {
                    acc.Withdraw(amount);
                    return;
                }

                Console.WriteLine("Insufficient balance");
                return;
            }

            Console.WriteLine("Account does not exist");
        }

        public static void Print(string[] args)
        {
            /*
            if(args.Length == 0)
            {
                throw new Exception("Not enough parameters...");
            }
            */

            int accId = int.Parse(args[0]);

            if(!accounts.ContainsKey(accId))
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            Console.WriteLine(accounts[accId]);
        }
    }
}
