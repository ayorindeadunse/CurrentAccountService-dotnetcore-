using System;
using System.ComponentModel.DataAnnotations;

namespace CurrentAccountService.Models.DTOs
{
	public class OpenAccountDTO
	{
		[Required(ErrorMessage = "Customer ID is required.")]
		public string CustomerID { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Initial credit must be a non-negative value. ")]
		public decimal InitialCredit { get; set; }
	}
}

