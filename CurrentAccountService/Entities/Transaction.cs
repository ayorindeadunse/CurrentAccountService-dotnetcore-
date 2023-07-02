using System;
namespace CurrentAccountService.Entities
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime TransactionDate { get; set; }
		public string? Narration { get; set; }
		public TransactionType TransactionType { get; set; }


		// refactor to include constructor
		public Transaction(string? description, decimal amount, TransactionType transactionType)
		{
			Id = Guid.NewGuid();
			Narration = description;
			Amount = amount;
			TransactionType = transactionType;
			TransactionDate = DateTime.UtcNow;
		}

		// Add parameterless constructor
		public Transaction()
		{

		}
	}
}

