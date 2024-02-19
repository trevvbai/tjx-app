using LiteDB;

namespace tjx_api;

public interface ILiteDbContext
{
	public LiteDatabase Database { get; }
}