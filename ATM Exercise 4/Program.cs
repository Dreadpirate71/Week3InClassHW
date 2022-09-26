using System;

namespace ATM_Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string accountNumber = "12345";
            string pinNumber = "1234";
            string enteredAccountNumber;
            string enteredPinNumber;
            string menuItemEntered = "0";
            int attemptAccount = 0;
            int attemptPin = 0;
            decimal depositAmount;
            decimal accountTotal = 0.00M;
            decimal withdrawalAmount;
            
            do
            {
                Console.WriteLine("Please enter you five digit account number:");
                enteredAccountNumber = Console.ReadLine();
                attemptAccount++;
            } while (enteredAccountNumber != accountNumber && attemptAccount < 5);

            //if too many wrong account numbers entered
            if (attemptAccount == 5)
            {
                Console.WriteLine("Too many wrong attemps! Please try again in 5 minutes.");
                Environment.Exit(0);
            }

            do
            {
                Console.WriteLine("Please enter you four digit pin number:");
                enteredPinNumber = Console.ReadLine();
                attemptPin++;
            } while (enteredPinNumber != pinNumber && attemptPin < 5);
            
            //if too many wrong pin numbers entered
            if (attemptPin == 5)
            {
                Console.WriteLine("Too many wrong attemps! Please try again in 5 minutes.");
                Environment.Exit(0);
            }
            while (menuItemEntered != "4")
            {
                Console.WriteLine("Please enter the number of the option from the menu that you would like to do:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit");
                menuItemEntered = Console.ReadLine();
                if (menuItemEntered == "1")
                {
                    Console.WriteLine("How much would you like to deposit?");
                    depositAmount = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("{0} has been deposited into account number {1}", depositAmount.ToString("C"), accountNumber);
                    accountTotal += depositAmount;
                    Console.WriteLine("The new account balance in account number {0} is {1}.", accountNumber, accountTotal.ToString("C"));
                }
                else if (menuItemEntered == "2")
                {
                    Console.WriteLine("How much would you like to withdrawal?");
                    withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                    if (withdrawalAmount > accountTotal)
                    {
                        Console.WriteLine("Withdrawal amount of {0} is more than total of {1} in account {2}.", withdrawalAmount.ToString("C"), accountTotal.ToString("C"), accountNumber);
                        Console.WriteLine("Please enter a withdrawal amount less than {0}.", accountTotal.ToString("C"));
                    }
                    else
                    {
                        Console.WriteLine("{0} has been withdrawn from account number {1}", withdrawalAmount.ToString("C"), accountNumber);
                        accountTotal -= withdrawalAmount;
                        Console.WriteLine("The new account balance in account number {0} is {1}.", accountNumber, accountTotal.ToString("C"));
                    }
                }
                else if (menuItemEntered == "3")
                {
                    Console.WriteLine("The current balance in account number {0} is {1}.", accountNumber, accountTotal.ToString("C"));
                }
            }
        }
    }
}
