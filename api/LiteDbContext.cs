using LiteDB;
using tjx_api.Entities;

namespace tjx_api;

public class LiteDbContext(string path) : ILiteDbContext
{
	public LiteDatabase Database { get; } = new(path);
}