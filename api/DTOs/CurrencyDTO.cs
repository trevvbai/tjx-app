namespace tjx_api.DTOs;

public class CurrencyDTO
{
	public string CurrencyCode { get; set; }
	public decimal ExchangeRate { get; set; }
	public DateOnly ValidFromDate { get; set; }
	public DateOnly? ValidToDate { get; set; }
	public bool IsValid 
	{
		get
		{
			if (!ValidToDate.HasValue)
			{
				return true;
			}
			return ValidFromDate <= ValidToDate.Value;
		}
	}
}