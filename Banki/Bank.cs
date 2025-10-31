using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banki
{
    class BankAccount
    {
        private static int accN = 1000;
        public  int accountNumber { get; private set; }
        public string ownerName { get; set; }
        public decimal balance { get; private set; } = decimal.Zero;

        public BankAccount(string ownerName, int accountNumber, decimal balance, Bank bank)
        {
            this.ownerName = ownerName;
            this.accountNumber = accN;
            accN++;
            this.balance = balance;
            bank.AddAccount(this);
        }
        public BankAccount(string ownerName, Bank bank)
        {
            this.ownerName=ownerName;
            bank.AddAccount(this);
            accountNumber=accN;
            accN++;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Payment has been done!");
            }

            else
            {
                Console.WriteLine("Enter a valid number!");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                Console.WriteLine("Operation has been done!");
            }
            else
            {
                
                Console.WriteLine("Enter the valid ammount");
            }
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"-------------------------\nOwner name: {ownerName}\nAccount number: {accountNumber}\nBalnace: {balance}");

        }


    }

    class Bank
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            bankAccounts.Add(account);
        }

        private BankAccount FindAccount(int accountNumber)
        {
            foreach (BankAccount account in bankAccounts)
            {
                if (account.accountNumber == accountNumber)
                {
                    return account;
                }

            }

            return null;
        }

        public void Transfer(int fromAccount, int toAccount, decimal amount)
        {
            BankAccount facc=FindAccount(fromAccount);
            BankAccount tacc=FindAccount(toAccount);

            facc.Withdraw(amount);
            tacc.Deposit(amount);
        }


    }
}
