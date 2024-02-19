namespace tjx_api.DTOs;

public class ProductDTO
{
	public string Name { get; set; }
	public string Description { get; set; }
	public int PriceInPennies { get; set; }
	public decimal Price => PriceInPennies / 100M; // convert penny to normal price

}