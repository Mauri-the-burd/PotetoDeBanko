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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Class1 class1 = new Class1();
        public double balance, amount, newBalance;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public Window2()
        {
            InitializeComponent();
            class1.getUserInfo();
            UserLabel.Content = class1.userinfo[0];
            BalanceLabel.Content = class1.userinfo[3];
            balance = Convert.ToDouble(BalanceLabel.Content);
            DateTimeDisplay.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        private void WithdrawTextBox_Click(object sender, RoutedEventArgs e)
        {
            bool withdrawalSuccessful = false;
            amount = Convert.ToDouble(WithdrawTextBox.Text);
            if (amount <= 0)
            {
                MessageBox.Show("Invalid amount please enter a realistic value");
                return;
            }
            if (amount > balance)
            {
                MessageBox.Show("You don't have enough money.");
                return;
            }

            withdrawalSuccessful = true;


            if (withdrawalSuccessful)
            {
                balance -= amount;
                BalanceLabel.Content = balance.ToString();

                updateBalance();
                Pincode pinCode = new Pincode();
                pinCode.Show();
                this.Close();
                MessageBox.Show("Enter Pincode");
                class1.LogTransaction("Withdrawal", (decimal)amount, (decimal)balance);
            }

        }

        private void updateBalance()
        {
            double currentBalance = GetBalanceFromFile();
            newBalance = currentBalance - amount;
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
