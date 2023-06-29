using System;
namespace CurrentAccountService.Entities
{
	public class Account
	{
		public Guid Id { get; set; }
		public string CustomerID { get; private set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public List<Transaction>? Transactions { get; set; }
	}
}

