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
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }
        public string CurrentTime 
        { 
            get 
            {
                return $"🕑 {DateTime.Now.Date.ToLongDateString()}. Terminal activated at: {DateTime.Now.ToShortTimeString()}.";
            } 
        }

        private void WebView_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            //ibanBtn.IsEnabled = true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = await webView.CoreWebView2.ExecuteScriptAsync("document.getElementById('demo').innerText");
            string iban = result.Trim().Replace("\"", "");
        }

        private void NewCustomerClick(object sender, RoutedEventArgs e)
        {
            NewCustomerWindow window= new();
            window.Show();
        }
    }
}
