using System.Windows;

namespace AtmSimulator
{
    public partial class InputDialog : Window
    {
        public string Answer { get; private set; }

        public InputDialog(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Answer = InputTextBox.Text;
            DialogResult = true;
            this.Close();
        }
    }
}
