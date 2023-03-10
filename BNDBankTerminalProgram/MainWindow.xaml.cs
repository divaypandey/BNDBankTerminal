using BNDBankTerminalProgram.Views;
using System;
using System.Windows;

namespace BNDBankTerminalProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string CurrentTime 
        { 
            get 
            {
                return $"🕑 {DateTime.Now.Date.ToLongDateString()}. Terminal activated at: {DateTime.Now.ToShortTimeString()}.";
            } 
        }

        private void NewCustomerClick(object sender, RoutedEventArgs e)
        {
            NewCustomerWindow window= new();
            window.Show();
        }

        private void NewBankAccountClick(object sender, RoutedEventArgs e)
        {
            NewBankAccountWindow window = new();
            window.Show();
        }

        private void DepositClick(object sender, RoutedEventArgs e)
        {
            DepositMoneyWindow window = new();
            window.Show();
        }

        private void TransferClick(object sender, RoutedEventArgs e)
        {
            TransferMoneyWindow window= new();
            window.Show();
        }

        private void CustomerInfoClick(object sender, RoutedEventArgs e)
        {
            CustomerInfoWindow window = new();
            window.Show();
        }

        private void BankAccountsClick(object sender, RoutedEventArgs e)
        {
            BankAccountsWindow window = new();
            window.Show();
        }

        private void TransactionHistoryCustomerClick(object sender, RoutedEventArgs e)
        {
            TransactionHistoryCustomerWindow window = new();
            window.Show();
        }

        private void TransactionHistoryAccountClick(object sender, RoutedEventArgs e)
        {
            TransactionHistoryAccountWindow window = new();
            window.Show();
        }
    }
}
