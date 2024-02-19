using Microsoft.AspNetCore.Mvc;

namespace tjx_api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(IDashboardRepository dashboardRepository) : ControllerBase
{
	[HttpGet("products")]
	public IActionResult GetAllProducts()
	{
		var productDTOs = dashboardRepository.GetProducts();
		return Ok(productDTOs);
	}

	[HttpGet("countries")]
	public IActionResult GetAllCountries()
	{
		var countryDTOs = dashboardRepository.GetCountries();
		return Ok(countryDTOs);
	}
	
	[HttpGet("currencies")]
	public IActionResult GetAllCurrencies()
	{
		var currencies = dashboardRepository.GetCurrencies();
		return Ok(currencies);
	}
}