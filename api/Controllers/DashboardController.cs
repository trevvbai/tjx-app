using Microsoft.AspNetCore.Mvc;

namespace tjx_api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController: ControllerBase
{
	[HttpGet("products")]
	public IActionResult GetProducts()
	{
		var products = new List<Product>
		{
			new Product
			{
				Name = "T-Shirt",
				Id = 1,
				Description = "Mens t-shirt, size medium",
				Price = 19.99
			}
		};

		return Ok(products);
	}
	
}

public class Product
{
	public string Name { get; set; }
	public int Id { get; set; }
	public string Description { get; set; }
	public double Price { get; set; }
}