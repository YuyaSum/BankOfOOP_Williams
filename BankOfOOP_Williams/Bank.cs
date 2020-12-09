using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfOOP_Williams
{
    class Bank
    {
        private List<string> transactionList = new List<string>();
        private List<decimal> moneyList = new List<decimal>();

        public int Login(List<Customers> customers, string userName, string password)
        {
            int inList = -1;
            for (int i = 0; i < customers.Count; i++)
            {
                if ((customers[i].UserName).ToLower() == userName && customers[i].Password == password)
                {
                    inList = i;
                }
            }
            return inList;
        }
        public void Withdraw(decimal money)
        {

            transactionList.Add("Withdraw");
            moneyList.Add(money);

        }

        public void Deposit(decimal money)
        {

            transactionList.Add("Deposit");
            moneyList.Add(money);

        }

        public decimal Balance()
        {
            if (moneyList.Count <= 0)
            {
                return 0m;
            }
            else
            {
                decimal changesMade = 0m;
                foreach (decimal item in moneyList)
                {
                    changesMade += item;
                }
                return changesMade;
            }
        }

        public void Logout()
        {
            transactionList = new List<string>();
            moneyList = new List<decimal>();
        }

        public override string ToString()
        {
            string transaction = "";
            for (int i = 0; i < transactionList.Count; i++)
            {
                if (transactionList[i] == "Withdraw")
                {
                    moneyList[i] = Decimal.Negate(moneyList[i]);
                }
                transaction += transactionList[i] + ":\t$" + moneyList[i] + "\n";
            }
            return transaction;
        }

    }
}
