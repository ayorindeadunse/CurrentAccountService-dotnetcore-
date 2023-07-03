using System;
using CurrentAccountService.Entities;
using CurrentAccountService.Repositories;

namespace CurrentAccountService.Util
{
	public static class DummyDataInitializer
	{
		public static void Initialize(ICustomerRepository customerRepository,
        IAccountRepository accountRepository)
		{
            var customer1 = new Customer
            {
                CustomerID = "123456",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                MobileNumber = "123-456-7890"
            };

            var account1 = new Account
            {
                AccountID = "accountID1",
                CustomerID = customer1.CustomerID
            };

            var transaction1 = new Transaction
            {
                Narration = "Initial deposit",
                Amount = 1000,
                TransactionType = TransactionType.Credit
            };

            //account1.Transactions.Add(transaction1);

            customerRepository.AddCustomer(customer1);
            accountRepository.AddAccount(account1);
            accountRepository.AddTransaction(account1.AccountID, transaction1, TransactionType.Credit);

            //      Customer #2 sample data

            var customer2 = new Customer
            {
                CustomerID = "789012",
                FirstName = "Ayorinde",
                MiddleName = "Olawale",
                LastName = "Adunse",
                Email = "ayorinde.adunse@rova.com",
                MobileNumber = "09039875170"
            };

            var account2 = new Account
            {
                AccountID = "accountID2",
                CustomerID = customer2.CustomerID
            };

            var transaction2 = new Transaction
            {
                Narration = "Bitcoin purchase",
                Amount = 500,
                TransactionType = TransactionType.Credit
            };

            var transaction3 = new Transaction
            {
                Narration = "Salary",
                Amount = 100000,
                TransactionType = TransactionType.Credit
            };

            var transaction4 = new Transaction
            {
                Narration = "Babysitter",
                Amount = 1000,
                TransactionType = TransactionType.Debit
            };

            //account2.Transactions.Add(transaction2);
            account2.Balance = transaction2.Amount;

            // update balances
           // account2.Transactions.Add(transaction3);
            account2.Balance = transaction3.Amount;

           // account2.Transactions.Add(transaction4);
            account2.Balance = transaction4.Amount;

            customerRepository.AddCustomer(customer2);
            accountRepository.AddAccount(account2);
            accountRepository.AddTransaction(account2.AccountID, transaction2,TransactionType.Credit);
            accountRepository.AddTransaction(account2.AccountID, transaction3, TransactionType.Debit);
            accountRepository.AddTransaction(account2.AccountID, transaction4, TransactionType.Debit);

            
           
        }

        
	}
}

