namespace tjx_api.Entities;

public class Currency
{
	public int _id { get; set; }
	public string CurrencyCode { get; set; }
	public decimal ExchangeRate { get; set; }
	public DateOnly ValidFromDate { get; set; }
	public DateOnly? ValidToDate { get; set; }
}