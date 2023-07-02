using System;
using CurrentAccountService.Entities;
using CurrentAccountService.Services.Abstract;

namespace CurrentAccountService.Services.Core
{
    public class AccountService : IAccountService
    {
        private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>();

        public Account GetAccountInformation(string customerID)
        {
            if (_accounts.TryGetValue(customerID, out var account))
                return account;

            return null;
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

