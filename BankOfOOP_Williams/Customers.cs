using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfOOP_Williams
{
    class Customers
    {
        string userName;
        string password;
        string customer;
        decimal balance;

        public Customers(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.customer = "x";
            this.balance = 0m;
        }

        public Customers(string userName, string password, string customer, decimal balance)
        {
            this.userName = userName;
            this.password = password;
            this.customer = customer;
            this.balance = balance;
        }

        public string UserName { get { return userName; } }

        public string Password { get { return password; } }

        public string Customer { get { return customer; } }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

    }
}
