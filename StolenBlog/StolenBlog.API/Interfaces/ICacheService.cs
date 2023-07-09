namespace StolenBlog.API.Interfaces
{
	public interface ICacheService
	{
		List<T> GetData<T>(string key);

		void SaveData<T>(string key, List<T> data, TimeSpan timespan);

		void UpdateData<T>(string key, List<T> data, TimeSpan timespan);
	}
}
