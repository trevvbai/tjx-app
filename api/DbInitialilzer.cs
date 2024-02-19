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
		PopulateInitialCountries();
		PopulateInitialCurrencies();
	}

	private void PopulateInitialCurrencies()
	{
		var currencyCollection = _context.Database.GetCollection<Currency>("Currency");

		// Check if the collection already has data to avoid duplicating initial data
		if (currencyCollection.Count() == 0)
		{
			var initialCurrencies = new List<Currency>
			{
				new() { _id = 1, CurrencyCode = "GBP", ExchangeRate = 1, ValidFromDate = new DateOnly(2024,1,1)},
				new() { _id = 2, CurrencyCode = "USD", ExchangeRate = 1.25919m, ValidFromDate = new DateOnly(2024,1,1), ValidToDate = new DateOnly(2024,12,25)},
				new() { _id = 3, CurrencyCode = "CAD", ExchangeRate = 1.69873m, ValidFromDate = new DateOnly(2024,1,1)},
				new() { _id = 4, CurrencyCode = "MXN", ExchangeRate = 21.460247m, ValidFromDate = new DateOnly(2024,1,1), ValidToDate = new DateOnly(2024,1,30)},
			};

			currencyCollection.InsertBulk(initialCurrencies);
		}	}

	private void PopulateInitialProducts()
	{
		var productsCollection = _context.Database.GetCollection<Product>("Product");

		// Check if the collection already has data to avoid duplicating initial data
		if (productsCollection.Count() == 0)
		{
			var initialProducts = new List<Product>
			{
				new() { _id = 1, Name = "T-shirt", Description = "Mens t-shirt, size medium", PriceInPennies = 1999 },
				new() { _id = 2, Name = "Jeans", Description = "Womens jeans, size small", PriceInPennies = 4599 },
				new() { _id = 3, Name = "Hat", Description = "Summer hat, one size", PriceInPennies = 1099 },
				new() { _id = 4, Name = "Coat", Description = "Unisex winter jacket, size large", PriceInPennies = 8099 },
				new() { _id = 5, Name = "Trainers", Description = "Womens fashion footwear, size 37", PriceInPennies = 5599 },
			};

			productsCollection.InsertBulk(initialProducts);
		}
	}
	
	private void PopulateInitialCountries()
	{
		var countryCollection = _context.Database.GetCollection<Country>("Country");

		// Check if the collection already has data to avoid duplicating initial data
		if (countryCollection.Count() == 0)
		{
			var initialCountries = new List<Country>
			{
				new() { _id = 1, Name = "United Kingdom", CountryCode = "UK", CurrencyCode = "GBP"},
				new() { _id = 2, Name = "United States", CountryCode = "USA", CurrencyCode = "USD"},
				new() { _id = 3, Name = "Canada", CountryCode = "CA", CurrencyCode = "CAD"},
				new() { _id = 4, Name = "Mexico", CountryCode = "MX", CurrencyCode = "MXN"},
			};

			countryCollection.InsertBulk(initialCountries);
		}
	}
	
}