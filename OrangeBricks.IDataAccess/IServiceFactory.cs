namespace OrangeBricks.IDataAccess
{
	public interface IServiceFactory
	{
		T GetService<T>();
	}
}