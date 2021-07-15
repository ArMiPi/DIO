using System;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            string opt = "0";

            while(!opt.ToUpper().Equals("X"))
            {
                opt = Console.ReadLine();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar uma conta");
            Console.WriteLine("2 - Remover uma conta");
            Console.WriteLine("3 - Listar contas");
            Console.WriteLine("4 - Realizar depósito");
            Console.WriteLine("5 - Realizar transfrência bancária");
            Console.WriteLine("6 - Realizar saque");
            Console.WriteLine("7 - Detalhes de uma conta");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
        }
    }
}
