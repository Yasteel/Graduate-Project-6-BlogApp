using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StolenBlog.API.Interfaces;
using System;

namespace StolenBlog.API.Services
{
	public class CacheService : ICacheService
	{
		private readonly IDistributedCache redis;

		public CacheService(IDistributedCache redis)
        {
			this.redis = redis;
		}

        public List<T> GetData<T>(string key)
		{
			var data = this.redis.GetString(key);

			if (data == null)
			{
				return null;
			}

			return JsonConvert.DeserializeObject<List<T>>(data);
		}

		public void SaveData<T>(string key, List<T> data, TimeSpan timespan)
		{
			var serializedData = JsonConvert.SerializeObject(data);

			var options = new DistributedCacheEntryOptions()
			{
				AbsoluteExpirationRelativeToNow = timespan,
			};

			this.redis.SetString(key, serializedData, options);
		}

		public void UpdateData<T>(string key, List<T> data, TimeSpan timespan)
		{
			var redisData = this.GetData<T>(key);

			foreach(var item in data)
			{
				if (redisData.Contains(item))
				{
					data.Remove(item);
				}
			}

			if(data.Count > 0)
			{
				redisData.Concat(data);

				this.SaveData<T>(key, redisData, timespan);
			}
		}
	}
}
