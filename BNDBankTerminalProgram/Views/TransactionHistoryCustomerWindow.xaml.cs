using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System.Collections.Generic;
using System.Windows;

namespace BNDBankTerminalProgram.Views
{
    public partial class TransactionHistoryCustomerWindow : Window
    {
        public bool Enabled { get; set; } = true;
        public List<Transaction> transactions { get; set; } = new();

        public Customer customer { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }
        public TransactionHistoryCustomerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customer = await new CustomerService().GetCustomerByEmail(emailInput.Text);
                if (customer is not null)
                {
                    transactions = new List<Transaction>(await new TransactionService().GetTransactionsByCustomerID(customer.CustomerID));
                }
            }
            catch
            {
                customer = new();
            }
            Enabled = false;
            ForceUIUpdate();
        }
    }
}
