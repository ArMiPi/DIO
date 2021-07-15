using System;
using System.Collections.Generic;

namespace BankAccounts
{
    public class Account
    {
        public Client Client { get; private set; }          // Client data
        public AccountType AccType { get; private set; }    // Pessoa Física or Pessoa Jurídica or ONG
        public DateTime Creation { get; private set; }      // Date of creation
        private float Balance { get; set; }                 // Account Balance
        public Condition Cond { get; private set; }         // Account Condition
        public List<string> Log { get; set; }               // Log of activities of the account

        public Account(Client client, AccountType accType, DateTime creation, float initialBalance)
        {
            Client = client;
            AccType = accType;
            Creation = creation;
            Cond = Condition.NoFunds;
            Deposit(initialBalance);
            Log = new List<string>();
        }

        public void Deposit(float value, bool transf = false)
        {
            DateTime time = DateTime.Now;

            Balance += value;

            if(Cond == Condition.InDebt)
            {
                if(Balance > 0)
                    Cond = Condition.OK;
                else if(Balance == 0)
                    Cond = Condition.NoFunds;
            }
            else if(Cond == Condition.NoFunds && Balance > 0)
                Cond = Condition.OK;
            
            if(!transf)
                Log.Add("Deposit: + " + value.ToString("F2") + "\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
        }

        public void Withdraw(float value, bool transf = false)
        {
            DateTime time = DateTime.Now;

            if(Cond == Condition.OK)
            {
                if(value > Balance)
                    Cond = Condition.InDebt;
                Balance -= value;
                
                if(!transf)
                    Log.Add("Withdraw: - " + value.ToString("F2") + "\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            }
            else
            {
                if(Cond == Condition.InDebt)
                    Console.WriteLine("This account has a debit to quit");
                else if(Cond == Condition.NoFunds)
                    Console.WriteLine("This account has no funds");

                Log.Add("Withdraw attempt\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            }
        }

        public void TransferTo(Account acc, float value)
        {
            if(acc != null)
            {
                DateTime time = DateTime.Now;

                if(Cond == Condition.OK)
                {
                    acc.Deposit(value, true);
                    acc.Log.Add("Transference from " + this.Client.Name + ": + " + value.ToString("F2") + "\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

                    this.Withdraw(value, true);
                    this.Log.Add("Transference to " + acc.Client.Name + ": - " + value.ToString("F2") + "\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                }
                else
                {
                    if(Cond == Condition.InDebt)
                        Console.WriteLine("This account has a debit to quit");
                    else if(Cond == Condition.NoFunds)
                        Console.WriteLine("This account has no funds");

                    Log.Add("Transference attempt to " + acc.Client.Name + "\t" + time.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                }
            }
            else
                Console.WriteLine("Account not found");
        }

        public void ShowLog()
        {
            foreach(string log in this.Log)
                Console.WriteLine(log);
        }

        public override string ToString()
        {
            return "\nClient : " + Client.Name + ", " + AccType
                    + "\nCreation Date: " + Creation.ToString("dd/MMMM/yyyy")
                    + "\nBalance: " + Balance.ToString("F2")
                    + "\nCondition: " + Cond
                    +" \n";
        }
    }
}