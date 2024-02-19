using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tjx_api.DTOs;
using tjx_api.Entities;

namespace tjx_api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController: ControllerBase
{
	private readonly LiteDbContext _db;

	public DashboardController(LiteDbContext db)
	{
		_db = db;
	}

	[HttpGet("products")]
	public IActionResult GetAllProducts()
	{
		var collection = _db.Database.GetCollection<Product>("Product");
		var products = collection.FindAll();

		var productDTOs = products.Select(x =>
			new ProductDTO()
			{
				Name = x.Name,
				Description = x.Description,
				PriceInPennies = x.PriceInPennies
			}
		).ToList();
		
		
		return Ok(productDTOs);
	}

	[HttpGet("countries")]
	public IActionResult GetAllCurrencies()
	{
		var collection = _db.Database.GetCollection<Country>("Country");
		var countries = collection.FindAll();

		var countryDTOs = countries.Select(x =>
			new CountryDTO()
			{
				Name = x.Name,
				CountryCode = x.CountryCode,
				CurrencyCode = x.CurrencyCode
			}
		);

		return Ok(countryDTOs);
	}
	
}