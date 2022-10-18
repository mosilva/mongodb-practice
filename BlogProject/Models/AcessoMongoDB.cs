using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace projetoBlog.Models
{
    public class AcessoMongoDB
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DATABASE_NAME = "MongoDataBlog";
        public const string COLLECTION_NAME = "";

        private static readonly IMongoClient _client;

        //static ConnectionMongoDb()
        //{
        //    _client = new Mo
        //}

    }
}
