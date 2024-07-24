using System;
using System.Collections.Generic;

namespace AtmSimulator
{
    public class Account
    {
        public int AccountNumber { get; }
        public decimal Balance { get; private set; }
        public decimal InterestRate { get; }
        public string AccountHolder { get; }
        public List<string> Transactions { get; }

        public Account(int accountNumber, decimal initialBalance, decimal interestRate, string accountHolder)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolder = accountHolder;
            Transactions = new List<string>
            {
                $"Account created with initial balance: {initialBalance:C}"
            };
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited: {amount:C} on {DateTime.Now}");
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add($"Withdrew: {amount:C} on {DateTime.Now}");
                return true;
            }
            return false;
        }
    }
}
