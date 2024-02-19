namespace tjx_api.Entities;

public class Product
{
	public string Name { get; set; }
	public int _id { get; set; }
	public string Description { get; set; }
	public int PriceInPennies { get; set; }
}