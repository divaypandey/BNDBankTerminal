using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BNDBankTerminalProgram.Views
{
    public partial class TransactionHistoryAccountWindow : Window
    {
        public bool Enabled { get; set; } = true;
        public List<Transaction> transactions { get; set; } = new();


        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }
        public TransactionHistoryAccountWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                transactions = new List<Transaction>(await new TransactionService().GetTransactionsByAccountID(Guid.Parse(accountInput.Text)));
            }
            catch { }
            Enabled = false;
            ForceUIUpdate();
        }
    }
}
