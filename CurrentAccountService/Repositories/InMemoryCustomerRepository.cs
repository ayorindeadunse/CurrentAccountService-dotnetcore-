using System;
using CurrentAccountService.Entities;

namespace CurrentAccountService.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public InMemoryCustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
             _customers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerByID(string CustomerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerID == CustomerId);
        }
    }
}

