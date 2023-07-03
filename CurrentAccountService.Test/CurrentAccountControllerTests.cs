using CurrentAccountService.Controllers;
using CurrentAccountService.Entities;
using CurrentAccountService.Models.DTOs;
using CurrentAccountService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CurrentAccountService.Test;

public class CurrentAccountControllerTests
{
    private readonly CurrentAccountController _controller;
    private readonly Mock<IAccountService> _accountServiceMock;

    public CurrentAccountControllerTests()
    {
        _accountServiceMock = new Mock<IAccountService>();
        _controller = new CurrentAccountController(_accountServiceMock.Object);
    }

    [Fact]
    public void OpenAccount_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var request = new OpenAccountDTO
        {
            CustomerID = "123456",
            InitialCredit = 1000
        };

        var account = new Account
        {
            Id = Guid.NewGuid(),
            AccountID = "accountID1",
            CustomerID = request.CustomerID,
            DateCreated = DateTime.UtcNow,
            Transactions = new List<Transaction>()
        };

        _accountServiceMock.Setup(x => x.OpenAccount(request.CustomerID, request.InitialCredit)).Returns(account);

        // Act

        var result = _controller.OpenAccount(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }


    [Fact]
    public void OpenAccount_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var request = new OpenAccountDTO
        {
            CustomerID = "",
            InitialCredit = 1000
        };

        // Add model state error to trigger BadRequest response
        _controller.ModelState.AddModelError("CustomerID", "Customer ID is required.");

        // Act
        var result = _controller.OpenAccount(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
