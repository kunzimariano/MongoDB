using System.Collections.Generic;
using MongoDB.Bson;

namespace ConsoleApp.Entities
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Tags { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
