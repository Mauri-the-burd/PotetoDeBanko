using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Class1
    {
        public string[] userinfo = new string[4];
        public List<string> Transactions = new List<string>();
        public void getUserInfo()
        {
            string filePath = "C:\\Users\\an2ne\\OneDrive\\Desktop\\input.txt";
            string separator = "";
            int i = 0;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] values = line.Split(separator);

                        foreach (var value in values)
                        {
                            userinfo[i] = value.Split(" ")[1];
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void LogTransaction(string transactionType, decimal amount, decimal balance)
        {
            string username = userinfo[0];
            Transactions.Add($"Username: {username} \nDate: {DateTime.Now:MM/dd/yyyy hh:mm:ss tt} \n{transactionType}: P{amount:F2} \nRemaining Balance:{balance:F2}\n");
            string filePath = "C:\\Users\\an2ne\\OneDrive\\Desktop\\bankstatement.txt";
            File.AppendAllLines(filePath, Transactions);
        }

        public void Withdraw(decimal amount, decimal balance)
        {

            LogTransaction("Withdrawal", amount, balance);
        }

        public void Deposit(decimal amount, decimal balance)
        {

            LogTransaction("Deposit", amount, balance);
        }

    }
}
