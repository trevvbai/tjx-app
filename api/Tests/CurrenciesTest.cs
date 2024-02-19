using Microsoft.AspNetCore.Mvc;
using Moq;
using tjx_api.Controllers;
using tjx_api.DTOs;
using tjx_api.Enums;
using Xunit;

namespace tjx_api.Tests;

public class CurrenciesTest
{
	[Fact]
	public void GetAllCurrencies_ReturnsAllCurrencies_AsCurrencyDTOs()
	{
		var testCurrencies = new List<CurrencyDTO>
		
		{
			new() { CurrencyCode = CurrencyCodes.GBP.ToString(), ExchangeRate = 1},
			new() { CurrencyCode = CurrencyCodes.USD.ToString(), ExchangeRate = 1.25919m},
			new() { CurrencyCode = CurrencyCodes.CAD.ToString(), ExchangeRate = 1.69873m},
			new() { CurrencyCode = CurrencyCodes.MXD.ToString(), ExchangeRate = 21.460247m,},
		};
		// Arrange
		var mockRepo = new Mock<IDashboardRepository>();
		mockRepo.Setup(x => x.GetCurrencies()).Returns(testCurrencies);

		var controller = new DashboardController(mockRepo.Object);

		// Act
		var res = controller.GetAllCurrencies();

		// Assert
		var okRes = Assert.IsType<OkObjectResult>(res);
		var currencies = Assert.IsType<List<CurrencyDTO>>(okRes.Value);
		Assert.Equal(4, currencies.Count);
		Assert.Contains(currencies, c => c.CurrencyCode == CurrencyCodes.USD.ToString());
		Assert.Contains(currencies, c => c.CurrencyCode == CurrencyCodes.GBP.ToString());
		Assert.Contains(currencies, c => c.CurrencyCode == CurrencyCodes.MXD.ToString());
		Assert.Contains(currencies, c => c.CurrencyCode == CurrencyCodes.CAD.ToString());
	}
	
}