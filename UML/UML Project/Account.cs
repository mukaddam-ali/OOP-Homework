using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UML_Project
{
    class Account
    {
        private string accountNumber;
        protected float balance;
        private string ownerName;
        private DateTime openDate;
        private string accountType;

        public Account(string accountNumber, float balance, string ownerName, DateTime openDate, string accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.ownerName = ownerName;
            this.openDate = openDate;
            this.accountType = accountType;
        }

        public void deposit(float amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public bool withdraw(float amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public float getBalance()
        {
            return balance;
        }


    }

    class SavingAccount : Account
    {

        public float interestRate;
        public float minimumBalance;
        public int monthlyLimit;
        private bool isCompoundInterest;

        public SavingAccount(float interestRate, float minimumBalance,int monthlyLimit,bool isCompoundInterest, string accountNumber, float balance, string ownerName, DateTime openDate, string accountType):base( accountNumber,  balance,  ownerName,  openDate,  accountType)
        {
        }        
        public void addInterest(){}
            
        public bool checkMinimumBalance()
        {
            return true;
        }

    }

    class CheckingAccount : Account
    {
        public float overdraftLimit;
        public float transactionFee;
        public string checkbookNumber;
        public int freeTransactions;
        public CheckingAccount(float overdraftLimit, float transactionFee, string checkbookNumber, int freeTransactions, string accountNumber, float balance, string ownerName, DateTime openDate, string accountType):base(accountNumber, balance, ownerName, openDate, accountType)
        {
            this.overdraftLimit = overdraftLimit;
            this.transactionFee = transactionFee;
            this.checkbookNumber = checkbookNumber;
            this.freeTransactions = freeTransactions;
        }

        public void deductFees()
        {

        }
        public void processCheck(string checkNo)
        {

        }
    }

    }