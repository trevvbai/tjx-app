
using tjx_api.Controllers;
using tjx_api.Entities;

namespace tjx_api;

public class DatabaseInitializer
{
	private readonly LiteDbContext _context;

	public DatabaseInitializer(LiteDbContext context)
	{
		_context = context;
	}
	
	public void InitDb()
	{
		PopulateInitialProducts();
		PopulateInitialCurrencies();
	}

	private void PopulateInitialProducts()
	{
		var productsCollection = _context.Database.GetCollection<Product>("Product");

		// Check if the collection already has data to avoid duplicating initial data
		if (productsCollection.Count() == 0)
		{
			var initialProducts = new List<Product>
			{
				new() { Id = 1, Name = "T-shirt", Description = "Mens t-shirt, size medium", PriceInPennies = 1999 },
				new() { Id = 2, Name = "Jeans", Description = "Womens jeans, size small", PriceInPennies = 4599 },
				new() { Id = 3, Name = "Hat", Description = "Summer hat, one size", PriceInPennies = 1099 },
				new() { Id = 4, Name = "Coat", Description = "Unisex winter jacket, size large", PriceInPennies = 8099 },
				new() { Id = 5, Name = "Trainers", Description = "Womens fashion footwear, size 37", PriceInPennies = 5599 },
			};

			productsCollection.InsertBulk(initialProducts);
		}
	}
	
	private void PopulateInitialCurrencies()
	{
		var countryCollection = _context.Database.GetCollection<Country>("Country");

		// Check if the collection already has data to avoid duplicating initial data
		if (countryCollection.Count() == 0)
		{
			var initialCountries = new List<Country>
			{
				new() { Id = 1, Name = "United Kingdom", CountryCode = "UK", CurrencyCode = "GBP"},
				new() { Id = 2, Name = "United States", CountryCode = "USA", CurrencyCode = "USD"},
				new() { Id = 3, Name = "Canada", CountryCode = "CA", CurrencyCode = "CAD"},
			};

			countryCollection.InsertBulk(initialCountries);
		}
	}
}