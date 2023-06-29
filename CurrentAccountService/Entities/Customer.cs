using System;
namespace CurrentAccountService.Entities
{
	public class Customer
	{
		public Guid Id { get; set; }
		public string CustomerID { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string MobileNumber { get; set; }
		public DateTime DateCreated { get; set; }
	}
}

