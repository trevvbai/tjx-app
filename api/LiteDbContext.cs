using LiteDB;
using tjx_api.Controllers;

namespace tjx_api;

public class LiteDbContext
{
	public LiteDatabase Database { get; }

	public LiteDbContext(string path)
	{
		Database = new LiteDatabase(path);
	}
}