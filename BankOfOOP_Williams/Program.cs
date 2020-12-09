using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankOfOOP_Williams
{
    class Program
    {
        public static void LoggedIn(Bank oop, List<Customers> customers, int position)
        {
            char choice = 'X';
            Console.WriteLine("\nWelcome " + customers[position].Customer + ", what would you like to do?\n");
            while (choice != 'L')
            {
                Console.WriteLine("(W)ithdraw  (D)eposit  (B)alance (L)ogout\n");
                choice = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (char.ToUpper(choice))
                {
                    case 'W':
                        {
                            Console.WriteLine("How much do you want to withdraw? (XX.XX)");
                            decimal money;

                            while (!Decimal.TryParse(Console.ReadLine(), out money))
                            {
                                Console.WriteLine("Please try again.");
                            }
                            money += 0.00m;
                            oop.Withdraw(money * -1);
                            Console.WriteLine("$" + money + " has been withdrawn from the account.");
                            break;
                        }
                    case 'D':
                        {
                            Console.WriteLine("How much do you want to deposit? (XX.XX)");
                            decimal money;

                            while (!Decimal.TryParse(Console.ReadLine(), out money))
                            {
                                Console.WriteLine("Please try again.");
                            }
                            money += 0.00m;
                            oop.Deposit(money);
                            Console.WriteLine("$" + money + " has been deposited to the account.");
                            break;
                        }
                    case 'B':
                        {
                            Console.WriteLine("Your current balance is $" + (customers[position].Balance + oop.Balance()) + "\n");
                            break;
                        }
                    case 'L':
                        {
                            choice = 'L';

                            decimal money = oop.Balance();
                            if (money < 0m)
                            {
                                Console.WriteLine("Total change to your account: ($" + Decimal.Negate(money) + ")");
                            }
                            else
                            {
                                Console.WriteLine("Total change to your account: $" + money);
                            }

                            if ((customers[position].Balance + money) < 0m)
                            {
                                Console.WriteLine("Your current Balance is: ($" + Decimal.Negate(customers[position].Balance + money) + ")");
                            }
                            else
                            {
                                Console.WriteLine("Your current Balance is: $" + (customers[position].Balance + money));
                            }

                            Console.WriteLine(oop.ToString());
                            customers[position].Balance += money;
                            oop.Logout();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("The fuck you doin' donkey?");
                            break;
                        }

                }
            }
        }

        static void Main(string[] args)
        {
            List<Customers> customers = new List<Customers>();
            Bank oop = new Bank();
            char choice = 'x';
            Console.WriteLine("Welcome to the Bank of OOP.\nWhat would you like to do?\n");

            Customers customer = new Customers("efudd", "efudd1", "Elmer Fudd", 345M);
            customers.Add(customer);
            customer = new Customers("bbunny", "bbunny1", "Bugs Bunny", 1722.12M);
            customers.Add(customer);
            customer = new Customers("tbird", "tbird1", "Tweety Bird", 45.44M);
            customers.Add(customer);

            while (choice != 'Q')
            {
                Console.WriteLine("(L)ogin (Q)uit\n");
                choice = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (char.ToUpper(choice))
                {
                    case 'L':
                        {
                            Console.WriteLine("Please enter a Username:");
                            string userName = (Console.ReadLine()).ToLower();
                            Console.WriteLine("Please enter a Password:");
                            string password = Console.ReadLine();

                            int position = oop.Login(customers, userName, password);

                            if (position > -1)
                            {
                                LoggedIn(oop, customers, position);
                                Console.WriteLine("What would you like to do?");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, but the credentials are incorrect.\n");
                            }

                            break;
                        }
                    case 'Q':
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you for using the Bank of OOP, have a wonderful day.");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("That isn't a valid key. Please try again.");
                            break;
                        }
                }
            }
        }
    }
}
