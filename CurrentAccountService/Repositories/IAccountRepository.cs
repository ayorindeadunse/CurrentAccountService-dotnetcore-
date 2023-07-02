using System;
using CurrentAccountService.Entities;

namespace CurrentAccountService.Repositories
{
	public interface IAccountRepository
	{
		IEnumerable<Account> GetAccountsByCustomerID(string customerID);
		Account GetAccountByID(string accountID);
		void AddAccount(Account account);
		void AddTransaction(string accountID, Transaction transaction, TransactionType transactionType); // check this

	}
}

