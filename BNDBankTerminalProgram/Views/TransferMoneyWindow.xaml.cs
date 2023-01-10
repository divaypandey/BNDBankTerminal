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
    /// <summary>
    /// Interaction logic for TransferMoneyWindow.xaml
    /// </summary>
    public partial class TransferMoneyWindow : Window
    {
        private TransactionService transactionService = new();

        public bool Enabled { get; set; } = true;
        public Transaction transaction { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }

        public TransferMoneyWindow()
        {
            InitializeComponent();
            DataContext= this;
        }

        private async void Transfer_Click(object sender, RoutedEventArgs e)
        {
            CreateTransactionRequest request = new()
            {
                FromAccountID = Guid.Parse(fromAccountID.Text),
                ToAccountID = Guid.Parse(toAccountID.Text),
                Amount = decimal.Parse(amount.Text)
            };

            var result = await transactionService.TransferMoney(request);
            if(result != null)
            {
                transaction = result;
                Enabled = false;
                bankSnackbar.Visibility = Visibility.Visible;
                ForceUIUpdate();
            }
        }
    }
}
