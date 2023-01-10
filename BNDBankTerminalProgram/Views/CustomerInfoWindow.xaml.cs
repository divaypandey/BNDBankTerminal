using BND_Core.Models;
using BNDBankTerminalProgram.Services;
using System.Windows;

namespace BNDBankTerminalProgram.Views
{
    public partial class CustomerInfoWindow : Window
    {
        public Customer customer { get; set; }
        public bool Enabled { get; set; } = true;

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }

        public CustomerInfoWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customer = await new CustomerService().GetCustomerByEmail(emailInput.Text);
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
