// AtmApplication.cs
using System.Collections.Generic;

namespace AtmSimulator
{
    public partial class AtmApplication
    {
        private Bank bank;

        public AtmApplication()
        {
            bank = new Bank();
        }

        public void AddAccount(Account account)
        {
            bank.AddAccount(account);
        }

        public Account RetrieveAccount(int accountNumber)
        {
            return bank.RetrieveAccount(accountNumber);
        }
    }
}
