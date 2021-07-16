using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankAccounts
{
    public static class Operations
    {
        public static void AddAccount(List<Account> list)
        {
            // Create Client
            Console.Clear();
            Console.WriteLine("Dados do cliente: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            if(!AccountExist(list, id))
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();

                Client client = new Client(name, id, email);

                // Create Account
                Console.WriteLine("Dados da conta: ");
                Console.Write("Tipo da conta (0 -> Pessoa Física / 1 -> Pessoa Jurídica / 2 -> ONG): ");
                int type = int.Parse(Console.ReadLine());
                AccountType accType = (AccountType)type;
                DateTime creation = DateTime.Now;
                Console.Write("Depósito Inicial: ");
                float deposit = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(client, accType, creation, deposit);

                list.Add(account);
                Console.WriteLine("\nConta criada com sucesso");
            }
            else
                Console.WriteLine("\nErro: Esse cliente já possui uma conta");
        }

        public static void RemoveAccount(List<Account> list)
        {
            Console.Clear();
            Console.WriteLine("Remoção de conta");
            Console.Write("ID: ");
            string id = Console.ReadLine();

            if(AccountExist(list, id))
            {
                list.Remove(GetAccount(list, id));
                Console.WriteLine("\nConta removida com sucesso");
            }
            else
                Console.WriteLine("\nErro: Conta não encontrada");
        }

        public static void ListAccounts(List<Account> list)
        {
            Console.Clear();

            if(list.Count > 0)
            {
                foreach(Account acc in list)
                    Console.WriteLine(acc.ToString());
            }
            else
                Console.WriteLine("Não há contas registradas");
        }

        private static bool AccountExist(List<Account> list, string id)
        {
            foreach(Account acc in list)
            {
                if(acc.Client.GetID().Equals(id))
                    return true;
            }
            return false;
        }

        private static Account GetAccount(List<Account> list, string id)
        {
            foreach(Account acc in list)
            {
                if(acc.Client.GetID().Equals(id))
                    return acc;
            }

            return null;
        }
    }
}