using MongoDB.Bson;

namespace ConsoleApp.Entities
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
