using System;
using CurrentAccountService.Models.DTOs;
using CurrentAccountService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CurrentAccountService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrentAccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public CurrentAccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public IActionResult OpenAccount([FromBody] OpenAccountDTO request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var account = _accountService.OpenAccount(request.CustomerID, request.InitialCredit);
			return Ok(account);
		}

		[HttpGet("{customerId}")]
		public IActionResult GetAccountInformation(string customerId)
		{
			var account = _accountService.GetAccountInformation(customerId);
			if (account == null)
				return NotFound();

			return Ok(account);
		}
	}
}

