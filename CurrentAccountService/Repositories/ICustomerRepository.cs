using System;
using CurrentAccountService.Entities;

namespace CurrentAccountService.Repositories
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAllCustomers();
		Customer GetCustomerByID(string CustomerID);
		void AddCustomer(Customer customer);
	}
}

