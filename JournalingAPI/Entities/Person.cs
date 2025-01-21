using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalingAPI.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace JournalingAPI.Entities
{
    public class Person : BaseEntity
    {
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}