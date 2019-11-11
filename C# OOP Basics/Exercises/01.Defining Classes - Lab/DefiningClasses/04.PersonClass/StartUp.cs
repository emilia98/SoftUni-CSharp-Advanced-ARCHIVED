using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main()
        {
            BankAccount acc1 = new BankAccount();
            BankAccount acc2 = new BankAccount();

            acc1.Balance = 25;
            acc2.Balance = 12.25m;

            List<BankAccount> accounts = new List<BankAccount>()
            {
                acc1, acc2
            };


            Person person = new Person("Pesho", 34, accounts);
            Console.WriteLine(person.GetBalance());
        }
    }
}
