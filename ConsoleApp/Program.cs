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
        static void Main(string[] args)
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();
            var database = server.GetDatabase("test");

            MongoCollection<User> usrCollection = database.GetCollection<User>("Users");

            var user = new User() { Username = "kun", Email = "some@mail.com" };
            usrCollection.Insert(user);

            Console.WriteLine(user.Id);




            Console.Read();

        }
    }
}
