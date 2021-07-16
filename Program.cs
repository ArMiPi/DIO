using System;
using System.Collections.Generic;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            string opt = "0";

            while(!opt.Equals("X"))
            {
                Operations.Menu();
                opt = Console.ReadLine().ToUpper();
                Operations.Option(opt, accounts);
            }
        }
    }
}
