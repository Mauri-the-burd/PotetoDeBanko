using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Class1 class1 = new Class1();

        public Window1()
        {
            InitializeComponent();
            class1.getUserInfo();
        }

        private void btn(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            lbl_accountnum.Text += btn.Content.ToString();
        }

        private void del(object sender, RoutedEventArgs e)
        {

        }

        private void sub(object sender, RoutedEventArgs e)
        {
            sub.Content += lbl_accountnum.Text.ToString();
        }

        public void readme()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\an2ne\\OneDrive\\Desktop\\read-file.txt"))
                {
                    string line;
                    int[] l;

                    while ((line = sr.ReadLine()) != null)
                    {


                        int[][] file = 

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Account number invalid!");
            }
        }
    }
}
