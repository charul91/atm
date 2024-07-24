using System;
using System.Windows;

namespace AtmSimulator
{
    public partial class CreateAccountWindow : Window
    {
        private AtmApplication atmApp;

        public CreateAccountWindow(AtmApplication atmApplication)
        {
            InitializeComponent();
            atmApp = atmApplication;
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int accountNumber = int.Parse(AccountNumberTextBox.Text);
                decimal initialBalance = decimal.Parse(InitialBalanceTextBox.Text);
                decimal interestRate = decimal.Parse(InterestRateTextBox.Text);
                string accountHolderName = AccountHolderTextBox.Text;

                Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                atmApp.AddAccount(newAccount);

                MessageBox.Show("Account created successfully!");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid input.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
