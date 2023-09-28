using Microsoft.EntityFrameworkCore.Storage;
using RecipesApi.Model.RedisModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApi.DataAccess.RedisRepository.IRedisRepository
{ 
    public interface IredisRepository<T> where T : class
    {
       Task<bool> DeleteAsyc(string id);
        Task<T> GetAsync(string? id);
        //Task<List<T>> GetAllAsync();
        Task<T> UpdateAsyc(T data, string id);
        Task<string> CheckId(string id);
    }
}
