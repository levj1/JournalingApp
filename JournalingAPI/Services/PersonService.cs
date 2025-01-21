using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalingAPI.Entities;
using JournalingAPI.Models;
using JournalingAPI.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace JournalingAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly MongoDbService<Person> _mongoDbService;

        public PersonService(IOptions<MongoDbSettings> setting)
        {
            _mongoDbService = new MongoDbService<Person>(setting, "persons");
        }
        public async Task CreateAsync(Person person)
        {
            await _mongoDbService.CreateAsync(person);
        }

        public async Task UpdateAsync(string id, Person person)
        {
            await _mongoDbService.UpdateAsync(id, person);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoDbService.DeleteAsync(id);
        }

        public async Task<List<Person>> GetAsync()
        {
            return await _mongoDbService.GetAsync();
        }

        public async Task<Person> GetAsync(string id)
        {
            return await _mongoDbService.GetAsync(id);
        }
    }
}