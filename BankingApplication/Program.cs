using System;
using System.ComponentModel;
using System.Dynamic;
using System.Transactions;
using static BankingApplication.Program;

namespace BankingApplication
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Liam", 11223344, 15000);
            //callig welcome message in Main method
            Welcome();

            int choice = 0;

            while (choice != 5)
            {
                Menu();

                //User enters his choice
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //calling account details menu inside the method for menu
                        account.ShowDetails();
                        break;

                    case 2:
                        Console.WriteLine($"Current Balance: Rs. {account.AccountBalance}");
                        break;

                    case 3:
                        //calling deposit menu inside the method for menu
                        account.Deposit();
                        break;

                    case 4:
                        //calling withdraw details menu inside the method for menu
                        account.Withdraw();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using People's Bank.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        //Method for Welcome message
      static void Welcome()
      {
           Console.WriteLine("==============================");
          Console.WriteLine("  Welcome to People's Bank");
          Console.WriteLine("==============================");
        }

        //Method for Menu
        static void Menu()
        {
            Console.WriteLine("===== BANK MENU =====");
            Console.WriteLine("1. View Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");
        }


        //Class for bank account
        // called all method exept main method inside the class
        public class BankAccount
        {
            public string AccountHolder;
            public int AccountNumber;
            public double AccountBalance;


            //list to store transaction
            public List<Transaction> Transaction = new List<Transaction>();
            public BankAccount(string holder, int number, double balance)
            {
                AccountHolder = holder;
                AccountNumber = number;
                AccountBalance = balance;
            }

            //details methods inside class
            public void ShowDetails()
            {
                Console.WriteLine(" ACCOUNT DETAILS");
                Console.WriteLine($"Holder Name : {AccountHolder}");
                Console.WriteLine($"Account No  : {AccountNumber}");
                Console.WriteLine($"Balance     : {AccountBalance}");
            }

            //deposit method inside class
            public void Deposit()
            {
                Console.WriteLine("Enter deposit amount: ");
                double amount = double.Parse(Console.ReadLine());

                if (amount > 0)
                {
                    AccountBalance = AccountBalance + amount;


                    

                    Console.WriteLine($" {amount} deposited successfully.");
                    Console.WriteLine($"New Balance:  {AccountBalance}");
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount!");
                }
            }

            //withdraw method inside class
            public void Withdraw()
            {
                Console.WriteLine("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());

                if (amount > 0 && amount <= AccountBalance)
                {
                    AccountBalance = AccountBalance - amount;

                    Console.WriteLine($" {amount} withdrawn successfully.");
                    Console.WriteLine($"Remaining Balance:  {AccountBalance}");
                }
                else
                {
                    Console.WriteLine("Enter a amount greater than 0 OR Your account balance is low!");
                }
            }

            public void showTransaction() 
            { 
              
            
            }
        }
        
    }
}
