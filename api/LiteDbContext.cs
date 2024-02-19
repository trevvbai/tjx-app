using LiteDB;
using tjx_api.Controllers;

namespace tjx_api;

public class LiteDbContext
{
	public LiteDatabase Database { get; }

	public LiteDbContext(string path)
	{
		Database = new LiteDatabase(path);
		PopulateInitialProducts();
	}

	private void PopulateInitialProducts()
	{
		var products = Database.GetCollection<Product>("Product");

		if (products.Count() == 0)
		{
			var initialProducts = new List<Product>
			{
				new() { Id = 1, Name = "T-shirt", Description = "Mens t-shirt, size medium", Price = 1999 },
				new() { Id = 2, Name = "Jeans", Description = "Womens jeans, size small", Price = 4599 },
				new() { Id = 3, Name = "Hat", Description = "Summer hat, one size", Price = 1099 },
				new() { Id = 4, Name = "Coat", Description = "Unisex winter jacket, size large", Price = 8099 },
				new() { Id = 5, Name = "Trainers", Description = "Womens fashion footwear, size 37", Price = 5599 },
			};

			products.InsertBulk(initialProducts);
			
		}
	}
}