using System;
using System.Transactions;
using CurrentAccountService.Entities;
using Transaction = CurrentAccountService.Entities.Transaction;

namespace CurrentAccountService.Repositories 
{
	public class InMemoryAccountRepository : IAccountRepository
	{
		private readonly List<Account> _accounts;

        public InMemoryAccountRepository()
        {
            _accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void AddTransaction(string accountID, Transaction transaction, TransactionType transactionType)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountID == accountID);
            if (account != null)
            {
                account?.Transactions?.Add(transaction);

                // check if it is a debit or credit transaction and update Balance accordingly.
                if (transactionType == TransactionType.Debit)
                {
                    account.Balance -= transaction.Amount;
                }
                else if (transactionType == TransactionType.Credit)
                {
                    account.Balance += transaction.Amount;
                }
            }
        }

        public Account GetAccountByID(string accountID)
        {
            return _accounts.FirstOrDefault(a => a.AccountID == accountID);
        }

        public IEnumerable<Account> GetAccountsByCustomerID(string customerId)
        {
            return _accounts.Where(a => a.CustomerID == customerId);
        }
    }
}

