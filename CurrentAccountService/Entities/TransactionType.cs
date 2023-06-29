using System;
using System.ComponentModel;

namespace CurrentAccountService.Entities
{
	public enum TransactionType
	{
        [Description("Debit")]
        Debit = 1,
        [Description("Credit")]
        Credit= 2
    }
}

