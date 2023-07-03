using System;
using CurrentAccountService.Entities;
using CurrentAccountService.Repositories;
using CurrentAccountService.Services.Abstract;

namespace CurrentAccountService.Services.Core
{
    public class AccountService : IAccountService
    {
  
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        public AccountService(IAccountRepository accountRepository,ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        public IEnumerable<Account> GetAccountInformation(string customerID)
        {
            var customer = _customerRepository.GetCustomerByID(customerID);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            var accounts = _accountRepository.GetAccountsByCustomerID(customerID);

            if (accounts != null)
            {
                return accounts;
            }
            throw new Exception("Account not found for the customer.");
        }

        public Account OpenAccount(string customerID, decimal initialCredit)
        {
            var customer = _customerRepository.GetCustomerByID(customerID);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

             string accountID = GenerateAccountID();
            
            var account = new Account
            {
                Id = Guid.NewGuid(),
                AccountID = accountID,
                CustomerID = customerID,
                DateCreated = DateTime.UtcNow,
                Transactions = new List<Transaction>()
            };
            _accountRepository.AddAccount(account);

            if (initialCredit != 0)
            {
                account?.AddTransaction("Initial deposit", initialCredit, TransactionType.Credit);
            }
            return account;
        }

        private string GenerateAccountID()
        {
            return Guid.NewGuid().ToString();
        }
       
    }
}

