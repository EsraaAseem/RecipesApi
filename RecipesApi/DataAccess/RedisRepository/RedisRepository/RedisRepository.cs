using RecipesApi.DataAccess.RedisRepository.IRedisRepository;
using RecipesApi.Model.RedisModel;
using StackExchange.Redis;
using System.Text.Json;

namespace RecipesApi.DataAccess.RedisRepository.RedisRepository
{
    public class RedisRepository<T>:IredisRepository<T> where T : class
    {
        private readonly IDatabase _database;
        private string _name;
        public RedisRepository(IConnectionMultiplexer redis, string name)
        {
            _database = redis.GetDatabase();
            _name = name; 
        }
        public async Task<bool> DeleteAsyc(string id)
        {
            return await _database.KeyDeleteAsync($"{_name}:{id}");
        }
        public async Task<T> GetAsync(string?id)
        {
            var data = await _database.StringGetAsync($"{_name}:{id}");
            return  data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<T>(data);
        }
        public async Task<string> CheckId(string id)
        {
            var data = await _database.StringGetAsync($"{_name}:{id}");
            return data;
        }
        public async Task<T> UpdateAsyc(T data,string? id)
        {
            var created = await _database.StringSetAsync($"{_name}:{id}", JsonSerializer.Serialize(data));
            if (!created) return null;
            return await GetAsync(id);
        }

        
    }
}
