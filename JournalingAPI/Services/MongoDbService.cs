using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalingAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JournalingAPI.Services
{
    public class MongoDbService<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbService(IOptions<MongoDbSettings> setting, string collectionName)
        {
            var client = new MongoClient(setting.Value.ConnectionString);
            var database = client.GetDatabase(setting.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<T> GetAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(T item) => await _collection.InsertOneAsync(item);
        public async Task UpdateAsync(string id, T updatedItem) => await _collection.ReplaceOneAsync(x => x.Id == id, updatedItem);
        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
    }
}