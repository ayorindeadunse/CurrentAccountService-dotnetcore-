﻿using System;
namespace CurrentAccountService.Entities
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime TransactionDate { get; set; }
		public string? Narration { get; set; }
		public TransactionType TransactionType { get; set; }
	}
}

