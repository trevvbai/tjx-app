using tjx_api.DTOs;

namespace tjx_api;

public interface IDashboardRepository
{
	public List<CurrencyDTO> GetCurrencies();
	public List<CountryDTO> GetCountries();
	public List<ProductDTO> GetProducts();
}