using tjx_api.DTOs;
using tjx_api.Entities;

namespace tjx_api;

public class DashboardRepository(ILiteDbContext _db) : IDashboardRepository
{
	public List<CurrencyDTO> GetCurrencies()
	{
		var collection = _db.Database.GetCollection<Currency>("Currency").FindAll();
		var currencyDTOs = collection.Select(x =>
			new CurrencyDTO()
			{
				CurrencyCode = x.CurrencyCode,
				ExchangeRate = x.ExchangeRate,
			}
		).ToList();

		return currencyDTOs;
	}

	public List<CountryDTO> GetCountries()
	{
		var countrySelection = _db.Database.GetCollection<Country>("Country");
		var currencyCollection = _db.Database.GetCollection<Currency>("Currency");
		var currencies = currencyCollection.FindAll().ToList();
		var today = DateOnly.FromDateTime(DateTime.Now);
		
		var countryDTOs = countrySelection.FindAll()
			.Where(country => currencies.Any(currency => currency.CurrencyCode == country.CurrencyCode && (currency.ValidToDate >= today || currency.ValidToDate == null)))
			.Select(country =>
				new CountryDTO()
				{
					Name = country.Name,
					CountryCode = country.CountryCode,
					CurrencyCode = country.CurrencyCode,
				})
			.ToList();

		return countryDTOs;

	}

	public List<ProductDTO> GetProducts()
	{
		var collection = _db.Database.GetCollection<Product>("Product");
		var products = collection.FindAll();

		var productDTOs = products.Select(x =>
			new ProductDTO()
			{
				Id = x._id,
				Name = x.Name,
				Description = x.Description,
				PriceInPennies = x.PriceInPennies
			}
		).ToList();

		return productDTOs;

	}
}