using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Class1 class1 = new Class1();
        double currentbalance, balance, amount, newBalance;
        public Window3()
        {
            InitializeComponent();
            class1.getUserInfo();

            double currentBalance = double.Parse(class1.userinfo[3]);
            UserLabel.Content = class1.userinfo[0];
            BalanceLabel.Content = class1.userinfo[3];
            balance = Convert.ToDouble(BalanceLabel.Content);
            DateTimeDisplay.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }
        private void WithdrawTextBox_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(WithdrawTextBox.Text, out amount))
            {
                try
                {
                    double amount = double.Parse(WithdrawTextBox.Text);
                    updateBalance(amount);
                    MessageBox.Show("Enter Pincode");
                    Pincode pinCode = new Pincode();
                    pinCode.Show();
                    this.Close();
                    class1.LogTransaction("Deposit", (decimal)amount, (decimal)balance);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deposit failed: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.");
            }
        }

        private void updateBalance(double balance)
        {
            double currentBalance = GetBalanceFromFile();
            newBalance = currentBalance + amount;
            string[] arrLine = File.ReadAllLines("C:\\Users\\an2ne\\OneDrive\\Desktop\\input.txt");
            arrLine[4 - 1] = "Balance: " + newBalance.ToString() + ".00";
            File.WriteAllLines("C:\\Users\\an2ne\\OneDrive\\Desktop\\input.txt", arrLine);
        }

        private double GetBalanceFromFile()
        {
            class1.getUserInfo();
            return double.Parse(class1.userinfo[3]);
        }

    }
}
