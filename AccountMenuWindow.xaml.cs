using System;
using System.Windows;

namespace AtmSimulator
{
    public partial class AccountMenuWindow : Window
    {
        private Account account;

        public AccountMenuWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Balance: {account.Balance:C}");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the amount to deposit:", "Deposit", "0");

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                account.Deposit(amount);
                MessageBox.Show($"Deposited: {amount:C}\nNew Balance: {account.Balance:C}");
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a positive number.");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the amount to withdraw:", "Withdraw", "0");

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                if (account.Withdraw(amount))
                {
                    MessageBox.Show($"Withdrew: {amount:C}\nNew Balance: {account.Balance:C}");
                }
                else
                {
                    MessageBox.Show("Insufficient funds.");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a positive number.");
            }
        }

        private void DisplayTransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            string transactions = string.Join(Environment.NewLine, account.Transactions);
            MessageBox.Show(transactions, "Transactions");
        }

        private void ExitAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
