using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System;
using System.Windows;

namespace BNDBankTerminalProgram.Views
{
    public partial class DepositMoneyWindow : Window
    {
        private BankAccountService accountService = new();
        public bool Enabled { get; set; } = true;
        public BankAccount account { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }

        public DepositMoneyWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Deposit_Click(object sender, RoutedEventArgs e)
        {
            if(Guid.TryParse(accountID.Text, out Guid accountIDGuid))
            {
                DepositMoneyRequest request = new()
                {
                    AccountID = accountIDGuid,
                    DepositAmount = Decimal.Parse(amount.Text)
                };

                var result = await accountService.DepositMoney(request);
                if (result != null)
                {
                    account = result;
                    bankSnackbar.Visibility = Visibility.Visible;
                    Enabled = false;
                    ForceUIUpdate();
                }
            }
        }
    }
}
