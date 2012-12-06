using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace ConsoleApp
{
    class Program
    {
        private const string ConnectionString = "mongodb://localhost";
        private static MongoClient _client;

        static void Main(string[] args)
        {
            _client = new MongoClient(ConnectionString);
            var database = _client.GetServer().GetDatabase("test");
            MongoCollection<User> usrCollection = database.GetCollection<User>("Users");

            if (!usrCollection.Exists())
                InsertSampleData(usrCollection);

            // some test queries
            IMongoQuery query = Query<User>.EQ(x => x.Tags, "uno");
            MongoCursor<User> tagUno = usrCollection.Find(query);

            query = Query<User>.EQ(x => x.Tags, "dos");
            MongoCursor<User> tagDos = usrCollection.Find(query);

            query = Query<User>.EQ(x => x.Tags, "tres");
            MongoCursor<User> tagTres = usrCollection.Find(query);

            query = Query<User>.EQ(x => x.Addresses[0].State, "NY");
            MongoCursor<User> ny = usrCollection.Find(query);

            //#########################################

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Tag uno");
            foreach (var user in tagUno)
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Tag dos");
            foreach (var user in tagDos)
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Tag tres");
            foreach (var user in tagTres)
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("NY");
            foreach (var user in ny)
            {
                Console.WriteLine(user.Username);
            }

            Console.Read();

        }

        private static void InsertSampleData(MongoCollection<User> collection)
        {


            var user = new User { Username = "charly", Email = "charly@mail.com", Tags = new List<string> { "uno", "dos", "tres" } };
            user.Addresses = new List<Address>
            {
                new Address() {City = "NY", State = "NY", Street = "Somewhere"},
                new Address() {City = "DC", State = "DC", Street = "Somewhere else"}
            };

            collection.Insert(user);

            user = new User { Username = "tom", Email = "tom@mail.com", Tags = new List<string> { "uno", "dos" } };
            user.Addresses = new List<Address>
            {
                new Address() {City = "NY", State = "NY", Street = "Somewhere"},
            };

            collection.Insert(user);

            user = new User { Username = "jayce", Email = "jayce@mail.com", Tags = new List<string> { "dos", "tres" } };
            user.Addresses = new List<Address>
            {
                new Address() {City = "DC", State = "DC", Street = "nowhere"}
            };

            collection.Insert(user);

        }
    }
}
