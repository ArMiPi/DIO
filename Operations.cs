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
            Console.WriteLine("----- CRIAÇÃO DE CONTA -----");
            Console.WriteLine();
            Console.WriteLine("DADOS DO CLIENTE");
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
                Console.WriteLine();
                Console.WriteLine("DADOS DA CONTA");
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
            Console.WriteLine("----- REMOÇÃO DE CONTA -----");
            Console.WriteLine();
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
            Console.WriteLine("----- LISTA DE CONTAS -----");

            if(list.Count > 0)
            {
                Console.WriteLine();
                foreach(Account acc in list)
                    Console.WriteLine(acc.ToString());
            }
            else
                Console.WriteLine("\nNão há contas registradas");
        }

        public static void Deposit(List<Account> list)
        {
            Console.Clear();
            Console.WriteLine("----- DEPÓSITO -----");
            Console.WriteLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();

            if(AccountExist(list, id))
            {
                Account acc = GetAccount(list, id);
                
                Console.Write("Valor do depósito: ");
                float value = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                acc.Deposit(value);

                Console.WriteLine("\nDepósito efetuado com sucesso");
            }
            else
                Console.WriteLine("\nErro: Conta não encontrada");
        }

        public static void Transference(List<Account> list)
        {
            Console.Clear();
            Console.WriteLine("----- TRANSFERÊNCIA -----");
            Console.WriteLine();
            Console.Write("ID1: ");
            string id1 = Console.ReadLine();
            if(!AccountExist(list, id1))
                Console.WriteLine("\nErro: Conta não encontrada");
            else
            {
                Account acc1 = GetAccount(list, id1);
                if(acc1.Cond != Condition.OK)
                    Console.WriteLine("\nEsta conta não pode realizar transferências");
                else
                {
                    Console.WriteLine("Valor da transferência: ");
                    float value = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    if(value > acc1.GetBalance())
                        Console.WriteLine("\nErro: Saldo insuficiente");
                    else
                    {
                        Console.WriteLine("ID2: ");
                        string id2 = Console.ReadLine();

                        if(!AccountExist(list, id2))
                            Console.WriteLine("\nErro: Conta não encontrada");
                        else
                        {
                            Account acc2 = GetAccount(list, id2);

                            acc1.TransferTo(acc2, value);

                            Console.WriteLine("\nTransferência realizada com sucesso");
                        }
                    }
                }
            }
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