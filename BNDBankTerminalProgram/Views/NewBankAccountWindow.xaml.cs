using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System;
using System.Windows;

namespace BNDBankTerminalProgram.Views
{
    public partial class NewBankAccountWindow : Window
    {
        private BankAccountService accountService = new();

        public bool Enabled { get; set; } = true;
        public BankAccount newAccount { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }

        public NewBankAccountWindow()
        {
            InitializeComponent();
            DataContext = this;
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void WebView_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Enabled = true;
        }

        private async void NewBank_Click(object sender, RoutedEventArgs e)
        {
            if(Guid.TryParse(customerID.Text, out Guid customerIDGuid))
            {
                string result = await webView.CoreWebView2.ExecuteScriptAsync("document.getElementById('demo').innerText");
                string iban = result.Trim().Replace("\"", "");

                CreateBankAccountRequest request = new()
                {
                    OwnerCustomerID = customerIDGuid,
                    IBAN = iban
                };
                var res = await accountService.CreateBankAccount(request);
                if (res != null)
                {
                    newAccount = res;
                    bankSnackbar.Visibility = Visibility.Visible;
                    Enabled= false;
                    ForceUIUpdate();
                }
            }
        }
    }
}
