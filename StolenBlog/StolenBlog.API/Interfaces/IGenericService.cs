namespace StolenBlog.API.Interfaces
{
	public interface IGenericService<T>
		where T : class
	{
		Task<List<T>> GetAll();

		Task<T> Get(int id);

		void Create(T model);

		void Update(int id, T model);

		void Delete(int id);
	}
}
