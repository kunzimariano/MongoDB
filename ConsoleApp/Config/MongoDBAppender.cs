using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using log4net.Appender;
using log4net.Core;

namespace ConsoleApp.Config
{
    public class MongoDBAppender : AppenderSkeleton
    {
        private static MongoClient _client;

        protected override void Append(LoggingEvent loggingEvent)
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["LogConnectionString"]);

            var database = _client.GetServer().GetDatabase("log");
            var c = database.GetCollection("log");
            string entry = RenderLoggingEvent(loggingEvent);
            c.Insert(new BsonDocument("logentry", entry));

        }
    }
}
