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
                Menu();
                opt = Console.ReadLine().ToUpper();
                Option(opt, accounts);
            }
        }

        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar uma conta");
            Console.WriteLine("2 - Remover uma conta");
            Console.WriteLine("3 - Listar contas");
            Console.WriteLine("4 - Realizar depósito");
            Console.WriteLine("5 - Realizar transferência bancária");
            Console.WriteLine("6 - Realizar saque");
            Console.WriteLine("7 - Detalhes de uma conta");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
        }

        static void Option(string opt, List<Account> list)
        {
            switch(opt)
            {
                case "1":
                    Operations.AddAccount(list);
                    break;
                case "2":
                    Operations.RemoveAccount(list);
                    break;
                case "3":
                    Operations.ListAccounts(list);
                    break;
                case "4":
                    Operations.Deposit(list);
                    break;
                case "5":
                    //Operations.Transference();
                    break;
                case "6":
                    //Operations.Withdraw();
                    break;
                case "7":
                    //Operations.AccountDetails();
                    break;
                case "C":
                    Console.Clear();
                    break;
                case "X":
                    break;
                default:
                    Console.WriteLine("Erro: Opção Inválida");
                    break;
            }
        }
    }
}
