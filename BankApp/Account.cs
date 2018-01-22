using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    enum AccountType // just like int, decimal etc (Value type), create my own value type = enum => AccountType
    {
        Checking, //hover over. it shows value = 0 as default. or i can set any number like Checking = 101,
        Savings,
        Loan,
        CD
    }
    /// <summary>
    /// (This is XML comment)
    /// This represents a bank account
    /// </summary>
    class Account // BankApp (right) - right click - Add - Class
    {
        private static int lastAccountNumber = 0;// to store a value => variable.  "static" one memory allocation for all memory allocation to use. Global variable concept. 
        #region Properties 
        /// <summary>
        /// Properties = Unique account for the account
        /// </summary>
        public int AccountNumber { get; private set; } // prop + tab*2 (short cut for this syntex)
        public string AccountName { get; set; }  // "get" = info provided by users. User input

        public DateTime CreatedDate { get; private set; }
        public decimal Balance { get; private set; }
        public AccountType TypeOfAccount { get; set; }
        public string EmailAddress { get; set; }
        #endregion

        #region Constructors
        public Account()
        {
            AccountNumber = ++lastAccountNumber; // "++ operator" pre-increment
            CreatedDate = DateTime.Now;  
        }

        /***
        public Account(string emailAddress) : this()
        {
            EmailAddress = emailAddress;
        }

        public Account(string emailAddress, AccountType typeofAccount) : this (emailAddress)
        {
            TypeOfAccount = typeofAccount;
        }
        ***/
        #endregion

        #region Methods
        public void Deposit(decimal amount)// public + type + method (parameter)/  {Parameter => type + method)
        {
            Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
