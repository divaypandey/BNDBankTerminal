using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BNDBankTerminalProgram.Views
{
    public partial class BankAccountsWindow : Window
    {
        public bool Enabled { get; set; } = true;
        public List<BankAccount> bankaccounts { get; set; } = new List<BankAccount>();

        public Customer customer { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }
        public BankAccountsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customer = await new CustomerService().GetCustomerByEmail(emailInput.Text);
                if(customer is not null)
                {
                    bankaccounts = new List<BankAccount>(await new BankAccountService().GetBankAccountsForCustomer(customer.CustomerID));
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
