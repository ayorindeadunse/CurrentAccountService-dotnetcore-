﻿using System;
using CurrentAccountService.Entities;

namespace CurrentAccountService.Services.Abstract
{
	public interface IAccountService
	{
		Account OpenAccount(string customerID, decimal initialCredit);
		IEnumerable<Account> GetAccountInformation(string customerID);
	}
}

