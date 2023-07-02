using System;
namespace CurrentAccountService.Entities
{
	public class Account
	{
		public Guid Id { get; set; }
		public string AccountID { get; set; }
		public decimal? Balance { get; set; }
		public string CustomerID { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public List<Transaction>? Transactions { get; set; }

		// refactored to include a constructor with a default balance and other properties
		public Account(string customerID)
		{
			CustomerID = customerID;
			Balance = 0;
			Transactions = new List<Transaction>();
		}

		// Add parameterless constructor
		public Account()
		{

		}

        public void AddTransaction(string description, decimal amount,TransactionType transactionType)
        {
            var transaction = new Transaction(description, amount,transactionType);
            Transactions.Add(transaction);
            Balance += amount;
        }
    }
}

