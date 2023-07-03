using System;
using CurrentAccountService.Entities;
using CurrentAccountService.Repositories;
using CurrentAccountService.Services.Abstract;

namespace CurrentAccountService.Services.Core
{
    public class AccountService : IAccountService
    {
        private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>();
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccountInformation(string customerID)
        {
            return _accountRepository.GetAccountsByCustomerID(customerID)?.FirstOrDefault();
        }

        public Account OpenAccount(string customerID, decimal initialCredit)
        {
            var account = new Account(customerID);

            if (initialCredit != 0)
                account.AddTransaction($"Initial credit: {initialCredit}",initialCredit,TransactionType.Credit);

            _accounts.Add(customerID, account);
            return account;
        }
    }
}

