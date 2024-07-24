using System.Windows;

namespace AtmSimulator
{
    public partial class MainWindow : Window
    {
        private Bank bank;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Simple input dialog to get account details
            InputDialog accountNumberDialog = new InputDialog("Enter Account Number:");
            if (accountNumberDialog.ShowDialog() == true)
            {
                int accountNumber = int.Parse(accountNumberDialog.Answer);

                InputDialog initialBalanceDialog = new InputDialog("Enter Initial Balance:");
                if (initialBalanceDialog.ShowDialog() == true)
                {
                    decimal initialBalance = decimal.Parse(initialBalanceDialog.Answer);

                    InputDialog interestRateDialog = new InputDialog("Enter Interest Rate:");
                    if (interestRateDialog.ShowDialog() == true)
                    {
                        decimal interestRate = decimal.Parse(interestRateDialog.Answer);

                        InputDialog accountHolderDialog = new InputDialog("Enter Account Holder's Name:");
                        if (accountHolderDialog.ShowDialog() == true)
                        {
                            string accountHolderName = accountHolderDialog.Answer;

                            // Create the account and add it to the bank
                            Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                            bank.AddAccount(newAccount);

                            MessageBox.Show("Account created successfully.");
                        }
                    }
                }
            }
        }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            InputDialog accountNumberDialog = new InputDialog("Enter Account Number:");
            if (accountNumberDialog.ShowDialog() == true)
            {
                int accountNumber = int.Parse(accountNumberDialog.Answer);
                Account account = bank.RetrieveAccount(accountNumber);

                if (account != null)
                {
                    AccountMenuWindow accountMenuWindow = new AccountMenuWindow(account);
                    accountMenuWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
