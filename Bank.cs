using System.Collections.Generic;

namespace AtmSimulator
{
    public class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
            // Initialize with 10 default accounts
            for (int i = 0; i < 10; i++)
            {
                accounts.Add(new Account(100 + i, 100, 3, $"Default User {i + 1}"));
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account RetrieveAccount(int accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }
    }
}
