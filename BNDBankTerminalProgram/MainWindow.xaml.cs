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
    }
}
