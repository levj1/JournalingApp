using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalingAPI.Entities;

namespace JournalingAPI.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAsync();
        Task<Person> GetAsync(string id);
        Task UpdateAsync(string id, Person person);
        Task CreateAsync(Person person);
        Task DeleteAsync(string id);
    }
}