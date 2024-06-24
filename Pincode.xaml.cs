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

namespace Bank
{
    /// <summary>
    /// Interaction logic for Pincode.xaml
    /// </summary>
    public partial class Pincode : Window
    {
        Class1 class1 = new Class1();

        public Pincode()
        {
            InitializeComponent();
            class1.getUserInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PinCodeBox.Password == class1.userinfo[2])

            {
                MessageBox.Show("Noice, poitato warrior! Get more money.");

            }
            else
            {
                MessageBox.Show("Invalid Pin Number, Try Again!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
