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
    /// Interaction logic for NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        private CustomerService customerService = new();

        public bool Enabled { get; set; } = true;
        public Customer newCustomer { get; set; }

        private void ForceUIUpdate() //dirty way coz x:Bind not available before WinUI3/UWP
        {
            DataContext = null;
            DataContext = this;
        }

        public NewCustomerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerRequest customerRequest = new()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Email = email.Text,
                CitizenID = citizenID.Text,
                ContactNumber = contactNumber.Text,
                PrimaryAddress = address.Text
            };
            Enabled = false;
            ForceUIUpdate();

            var request = await customerService.CreateCustomer(customerRequest);

            if(request != null)
            {
                newCustomer= request;
                customerSnackbar.Visibility = Visibility.Visible;
                ForceUIUpdate();
            }
        }
    }
}
