using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("***");
            while (true)
            {

                Console.WriteLine("0.Exit");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdrawal");
                Console.WriteLine("4. Print all accounts");

                Console.Write("Select an option:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting");
                        return;
                    case "1":
                        Console.Write("Email Address:");
                        var emailAddress = Console.ReadLine();
                        var accountTypes = Enum.GetNames(typeof(AccountType));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                        }
                        Console.Write("Select an account type:");
                        var accountType = Convert.ToInt32(Console.ReadLine()); // "ToInt32" = 32 bytes value
                        Console.Write("Deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress, (AccountType)(accountType - 1), amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, TA: { account.TypeOfAccount}, B: { account.Balance:C} ");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Select an account number:");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Deposit amount:");
                        var depositAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, depositAmount);
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Select an account number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Withdraw amount:");
                        var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, withdrawAmount);

                        break;
                    case "4":
                        PrintAllAccounts();
                        break;



                }

            }
        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAccounts();
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN: {acnt.AccountNumber}, TA: { acnt.TypeOfAccount}, B: { acnt.Balance:C} ");

            }
        }
    }
}

/***
 * // if don't see 'public' or 'private' (see just static), it's 'private' as default.  Never delete "Main" method. 
        {
            // to create instance "Account" : new + instance name();
            // instantiating an object or instance or constructing an object
            /***
            var account = new Account  // "new" = constructor = 'special method' = they don't return anything
            {
                EmailAddress = "test@test.com",
                TypeOfAccount = AccountType.Checking
            };
            // account.AccountNumber = 1234;
            // account.Balance = 100000000;
            // now, i want to make Balance info above unwritable (inaccessible).
            // add "private" in front of Set;
            account.Deposit(101.10M); // this is decimal representation 
           
            var account = Bank.CreateAccount("test@test.com", initialBalance: 101.10M);
account.Withdraw(10M);
            Console.WriteLine($"Account Number: {account.AccountNumber}," + 
                $"TA: {account.TypeOfAccount}," + 
                $"Balance: {account.Balance:C}," + 
                $"EA: {account.EmailAddress}");

            var account2 = Bank.CreateAccount("test2@test.com", initialBalance: 201.10M);
account2.Deposit(51.10M);
            Console.WriteLine($"Account Number: {account2.AccountNumber}," +
                $"TA: {account2.TypeOfAccount}," +
                $"Balance: {account2.Balance:C}," +
                $"EA: {account2.EmailAddress}");
    ***/