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
                Id = Guid.NewGuid(),
                CustomerID = "123456",
                FirstName = "John",
                MiddleName = "Quincy",
                LastName = "Adams",
                Email = "john.adams@rotund.com",
                MobileNumber = "123-456-7890",
                DateCreated = DateTime.UtcNow
            };

            var account1 = new Account
            {
                Id = Guid.NewGuid(),
                AccountID = "accountID1",
                CustomerID = customer1.CustomerID,
                DateCreated = DateTime.UtcNow,
                Transactions = new List<Transaction>(),
            };

            var transaction1 = new Transaction
            {
                Id = Guid.NewGuid(),
                Narration = "Initial deposit",
                Amount = 1000,
                TransactionType = TransactionType.Credit,
                TransactionDate = DateTime.UtcNow
            };

            account1.Transactions.Add(transaction1);

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
                MobileNumber = "09039875170",
                DateCreated = DateTime.UtcNow
            };

            var account2 = new Account
            {
                Id = Guid.NewGuid(),
                AccountID = "accountID2",
                CustomerID = customer2.CustomerID,
                DateCreated = DateTime.UtcNow,
                Transactions = new List<Transaction>(),
            };

            var transaction2 = new Transaction
            {
                Id = Guid.NewGuid(),
                Narration = "Bitcoin purchase",
                Amount = 500,
                TransactionType = TransactionType.Credit,
                TransactionDate = DateTime.UtcNow,
            };

            var transaction3 = new Transaction
            {
                Id = Guid.NewGuid(),
                Narration = "Salary",
                Amount = 100000,
                TransactionType = TransactionType.Credit,
                TransactionDate = DateTime.UtcNow
            };

            var transaction4 = new Transaction
            {
                Id = Guid.NewGuid(),
                Narration = "Babysitter",
                Amount = 1000,
                TransactionType = TransactionType.Debit,
                TransactionDate = DateTime.UtcNow
            };

            account2.Transactions.Add(transaction2);

            // update balances
            account2.Transactions.Add(transaction3);

            account2.Transactions.Add(transaction4);

            customerRepository.AddCustomer(customer2);
            accountRepository.AddAccount(account2);
            accountRepository.AddTransaction(account2.AccountID, transaction2,TransactionType.Credit);
            accountRepository.AddTransaction(account2.AccountID, transaction3, TransactionType.Debit);
            accountRepository.AddTransaction(account2.AccountID, transaction4, TransactionType.Debit);           
        }        
	}
}

